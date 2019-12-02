using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Tastic.classes
{
    public class FTP
    {
        private bool uploadFile()
        {
            try
            {
                // var localpath = fileForm.FileName;

                string target = "ftp://" + Properties.Settings.Default.ftp_host +
                         ":21";
                //try to remove the file if it already exists on the ftp server
                removeFile(target);
                using (var client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(Properties.Settings.Default.ftp_pass,
                        Properties.Settings.Default.ftp_pass);
                    //client.UploadFile(target, WebRequestMethods.Ftp.UploadFile, origin);
                }

                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        private void removeFile(string target)
        {
            try
            {
                var request = (FtpWebRequest)WebRequest.Create(target);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = new NetworkCredential(Properties.Settings.Default.ftp_user,
                    Properties.Settings.Default.ftp_pass);
                request.GetResponse();
            }
            catch (Exception)
            {
                //ignore
            }
        }
    }
}