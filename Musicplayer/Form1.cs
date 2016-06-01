using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Net;

namespace Musicplayer
{

    public partial class Form1 : Form
    {
        WMPLib.IWMPMedia[] wMedia;
        public Form1()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(axWindowsMediaPlayer1_PlayStateChange);
        }


        private void buttonOpen_Click(object sender, EventArgs e)
        {
            WMPLib.IWMPPlaylist playlist = axWindowsMediaPlayer1.playlistCollection.newPlaylist("myplaylist");
            WMPLib.IWMPMedia media;
            listBoxSong.Items.Clear();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Boolean mp3 = true;
                Boolean m3u = false;
                foreach (string file in openFileDialog.FileNames)
                {
                    FileInfo fi = new FileInfo(file);
                    if(fi.Extension!=".mp3"&&fi.Extension!=".wav")
                    {
                        mp3 = false;
                    }
                    if(fi.Extension==".m3u")
                    {
                        m3u = true;
                    }
                }
                if(mp3)
                {
                    foreach (string file in openFileDialog.FileNames)
                    {
                        media = axWindowsMediaPlayer1.newMedia(file);
                        playlist.appendItem(media);
                        TagLib.File mediaNow = TagLib.File.Create(file);
                        if (mediaNow.Tag.Performers.Length > 0 && mediaNow.Tag.Title != null)
                        {
                            listBoxSong.Items.Add(mediaNow.Tag.Performers[0].ToString() + " - " + mediaNow.Tag.Title.ToString());
                        }
                        else
                        {
                            listBoxSong.Items.Add(media.name);
                        }
                    }
                }
                if(m3u)
                {
                    playlist = axWindowsMediaPlayer1.newPlaylist("myPlaylist",openFileDialog.FileNames[0]);
                    for(int i=0;i<playlist.count;i++)
                    {
                        TagLib.File mediaNow = TagLib.File.Create(playlist.Item[i].sourceURL);
                        if (mediaNow.Tag.Performers.Length > 0 && mediaNow.Tag.Title != null)
                        {
                            listBoxSong.Items.Add(mediaNow.Tag.Performers[0].ToString() + " - " + mediaNow.Tag.Title.ToString());
                        }
                        else
                        {
                            listBoxSong.Items.Add(playlist.Item[i].name);
                        }
                    }
                }
            }
            axWindowsMediaPlayer1.currentPlaylist = playlist;
            axWindowsMediaPlayer1.Ctlcontrols.play();
            if(axWindowsMediaPlayer1.currentMedia!=null)
            {
                listBoxSong.SelectedItem = axWindowsMediaPlayer1.currentMedia.name;
            }
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
        }
        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if(axWindowsMediaPlayer1.currentMedia!=null)
            {
                TagLib.File mediaNow = TagLib.File.Create(axWindowsMediaPlayer1.currentMedia.sourceURL);
                if (mediaNow.Tag.Performers.Length>0&&mediaNow.Tag.Title!=null)
                {
                    listBoxSong.SelectedItem = (mediaNow.Tag.Performers[0].ToString() + " - " + mediaNow.Tag.Title.ToString());
                    this.Text = mediaNow.Tag.Performers[0].ToString() + " - " + mediaNow.Tag.Title.ToString();
                }
                else{
                    this.Text = axWindowsMediaPlayer1.currentMedia.name;
                    listBoxSong.SelectedItem = axWindowsMediaPlayer1.currentMedia.name;
                }
                if (mediaNow.Tag.Pictures.Length > 0)
                {
                    MemoryStream ms = new MemoryStream(mediaNow.Tag.Pictures[0].Data.Data);
                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                    Bitmap bp = new Bitmap(image);
                    int a, r, g, b;
                    a = 0; r = 0; g = 0; b = 0;
                    for (int y = 1; y < bp.Height; y++)
                    {
                        for (int x = 1; x < bp.Width; x++)
                        {
                            a += bp.GetPixel(x, y).A;
                            r += bp.GetPixel(x, y).R;
                            g += bp.GetPixel(x, y).G;
                            b += bp.GetPixel(x, y).B;
                        }
                    }
                    int cc = bp.Height * bp.Width;
                    Color cl = Color.FromArgb(255 ,r / cc, g / cc, b / cc);
                    this.BackColor = cl;
                }else
                {
                    this.BackColor = Color.AliceBlue;
                }
                if(checkBoxOutput.Checked)
                {
                    if(File.Exists("output.html"))
                    {
                        File.Delete("output.html");
                    }
                    if(File.Exists("output.txt"))
                    {
                        File.Delete("output.txt");
                    }
                    string color = "#A7FFF0";
                    if (mediaNow.Tag.Pictures.Length > 0)
                    {
                        MemoryStream ms = new MemoryStream(mediaNow.Tag.Pictures[0].Data.Data);
                        System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                        image.Save("output.jpg");
                        Bitmap bp = new Bitmap(image);
                        int a, r, g, b;
                        a = 0;r = 0;g = 0;b = 0;
                        for(int y=1; y<bp.Height;y++)
                        {
                            for(int x=1;x<bp.Width;x++)
                            {
                                a+=bp.GetPixel(x, y).A;
                                r += bp.GetPixel(x, y).R;
                                g += bp.GetPixel(x, y).G;
                                b += bp.GetPixel(x, y).B;
                            }
                        }
                        int cc = bp.Height * bp.Width;
                        Color cl=Color.FromArgb(a / cc, r / cc, g / cc, b / cc);
                        color = ColorTranslator.ToHtml(cl).ToString();
                        if(checkBoxUpload.Checked)
                        {
                            uploadImageToServer("output.jpg", "output.jpg");
                        }
                    }else
                    {
                        Image img = Image.FromFile("notfound.png");
                        img.Save("output.jpg");

                    }
                    using (StreamWriter sw = File.CreateText("output.html"))
                    {
                        sw.WriteLine("<html>");
                        sw.WriteLine("<head>");
                        sw.WriteLine("<meta charset='unicode' http-equiv='cache-control' content='no-cache'>");
                        sw.WriteLine("<link rel='stylesheet' href='stylesheet.css'>");
                        //sw.WriteLine("<script src=\"jquery-1.12.3.js\"></script>");
                        //sw.WriteLine("<script type='text/javascript'>"); sw.WriteLine("function refresh()");sw.WriteLine("{	setTimeout(function(){ $.ajax({");sw.WriteLine("    url : \"http://trivernis.byethost7.com/Music/index.html? \" + (new Date()).getMilliseconds(),");
                        //sw.WriteLine("dataType : \"text\",");sw.WriteLine("    ifModified : true,");sw.WriteLine("    success : function(data, textStatus) {");sw.WriteLine("      if (textStatus != \"notmodified\") {");sw.WriteLine("        location.href = location.href;");
                        //sw.WriteLine("}}});}, 1000);}");
                        //sw.WriteLine("</script>");
                        sw.WriteLine("</head>");
                        sw.WriteLine("<body style='background-color:"+color+"' onLoad='refresh()'>");
                        if(mediaNow.Tag.Pictures.Length > 0)
                        {
                            sw.WriteLine("<img class='art' src='output.jpg'/>");
                        }else
                        {
                            sw.WriteLine("<img class='art' src='" + this.searchForImage(axWindowsMediaPlayer1.currentMedia.name) + "'/>");
                        }
                        if(mediaNow.Tag.Performers.Length > 0 && mediaNow.Tag.Title != null&&mediaNow.Tag.Album!=null)
                        {
                            sw.WriteLine("<p class='artist'>"+mediaNow.Tag.Performers[0]+"</p>");
                            sw.WriteLine("<p class='title'>"+mediaNow.Tag.Title+"</p>");
                            sw.WriteLine("<p class='album'>"+mediaNow.Tag.Album+"</p>");
                        }
                        else
                        {
                            sw.WriteLine("<p class='artist'>"+axWindowsMediaPlayer1.currentMedia.name+"</p>");
                        }
                        sw.WriteLine("</body>");
                        sw.WriteLine("</html>");

                    }
                    if(checkBoxUpload.Checked)
                    {
                        uploadToServer("output.html", "index.html");
                    }
                    FileInfo fih = new FileInfo("output.html");
                    WebsiteToImage websiteToImage = new WebsiteToImage("file:///"+fih.FullName,"weboutput.jpg");
                    websiteToImage.Generate();
                    using (StreamWriter sw = File.CreateText("background.html"))
                    {
                        sw.WriteLine("<html>");
                        sw.WriteLine("<body style=\"background-color:"+color+"\">");
                        sw.WriteLine("</body>");
                    }
                    FileInfo fib = new FileInfo("background.html");
                    WebsiteToImage websitetoImage = new WebsiteToImage("file:///" + fib.FullName, "background.jpg");
                    websitetoImage.Generate();
                    using (StreamWriter sw = File.CreateText("output.txt"))
                    {
                        if (mediaNow.Tag.Performers.Length > 0 && mediaNow.Tag.Title != null && mediaNow.Tag.Album != null)
                        {
                            sw.WriteLine(mediaNow.Tag.Performers[0]);
                            sw.WriteLine(mediaNow.Tag.Title);
                            sw.WriteLine(mediaNow.Tag.Album);
                        }
                        else
                        {
                            sw.WriteLine(axWindowsMediaPlayer1.currentMedia.name);
                        }
                    }
                }
            }
        }
        private void listBoxSong_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void checkBoxShuffle_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxShuffle.Checked)
            {
                axWindowsMediaPlayer1.settings.setMode("shuffle", true);
            }else
            {
                axWindowsMediaPlayer1.settings.setMode("shuffle", false);
            }
        }
        private void uploadToServer(string filename, string serverfile)
        {
            deleteFromServer(serverfile);
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://b7_18021240@ftp.byethost7.com/htdocs/Music/"+serverfile);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("b7_18021240", "Findus1608");

            // Copy the contents of the file to the request stream.
            StreamReader sourceStream = new StreamReader(filename,Encoding.Unicode);
            byte[] fileContents = Encoding.Unicode.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);

            response.Close();
        }
        private void uploadImageToServer(string Image, string serverfile)
        {
            deleteFromServer(serverfile);
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://b7_18021240@ftp.byethost7.com/htdocs/Music/" + serverfile);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("b7_18021240", "Findus1608");

            // Copy the contents of the file to the request stream.
            byte[] fileContents = File.ReadAllBytes(Image);
            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);

            response.Close();
        }
        private void deleteFromServer(string filename)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://b7_18021240@ftp.byethost7.com/htdocs/Music/"+filename);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("b7_18021240", "Findus1608");
        }
        private string searchForImage(string searchstring)
        {
            Google.API.Search.GimageSearchClient ImageSearch = new Google.API.Search.GimageSearchClient("http://google.de");
            try { return (ImageSearch.Search(searchstring, 1)[1].VisibleUrl); } catch
            {
                return ("notfound.png");
            }
        }
    }
}
