using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AppEleicoes
{
    class FTP
    {
        public static IConfigurationRoot Configuration { get; set; }

        public FTP()
        {
            var _configuration = new ConfigurationBuilder()
                                //.SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true);
            Configuration = _configuration.Build();
        }

        public event EventHandler<UploadProgressEventArgs> UploadProgress;

        public int Upload(string file, int idx = -1)
        {
            try
            {
                bool conLocal = true;
                string ftpUser, ftpPassword, ftpHost;

                if (conLocal)
                {
                    ftpUser = Configuration.GetSection("ftp").GetValue<string>("user");
                    ftpPassword = Configuration.GetSection("ftp").GetValue<string>("password");
                    ftpHost = Configuration.GetSection("ftp").GetValue<string>("host");
                }
                else
                {
                    ftpUser = Configuration.GetSection("ftp2").GetValue<string>("user");
                    ftpPassword = Configuration.GetSection("ftp2").GetValue<string>("password");
                    ftpHost = Configuration.GetSection("ftp2").GetValue<string>("host");
                }

                FileInfo fileUpload = new FileInfo(file);

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpHost +"/file" + idx + fileUpload.Extension);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential { UserName = ftpUser, Password = ftpPassword };
                request.KeepAlive = false;
                request.UseBinary = true;
                request.ContentLength = fileUpload.Length;

                using (FileStream fs = fileUpload.OpenRead())
                {
                    using(Stream stream = request.GetRequestStream())
                    {
                        byte[] buffer = new byte[8192];
                        int bytesSend = 0, bytes;

                        while (bytesSend < fileUpload.Length)
                        {
                            bytes = fs.Read(buffer, 0, buffer.Length);
                            stream.Write(buffer, 0, bytes);
                            bytesSend += bytes;

                            int percent = (int)((long)(bytesSend * 100) / fileUpload.Length);

                            UploadProgressEventArgs args = new UploadProgressEventArgs {
                                percent = percent
                            };
                            OnUploadProgress(args);
                        }
                    }
                }

                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        protected virtual void OnUploadProgress(UploadProgressEventArgs e)
        {
            UploadProgress?.Invoke(this, e);
        }
    }

    public class UploadProgressEventArgs : EventArgs
    {
        public int percent { get; set; }
    }
}
