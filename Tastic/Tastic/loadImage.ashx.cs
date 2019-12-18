﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Security.Principal;
using System.Web;
using System.Windows;

namespace Tastic
{
    /// <summary>
    /// Summary description for loadImage
    /// </summary>
    public class loadImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            // Unsure about the speed of this code.
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int bytesRead = 0;
            byte[] buffer = new byte[2048];

            // Get the GET parameter
            string image = context.Request.QueryString["image"];

            // Create a request for the image
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"ftp://ftp.feddema.dev/{image}");
            request.KeepAlive = true;
            request.EnableSsl = true;
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(Properties.Settings.Default.ftp_user, Properties.Settings.Default.ftp_pass);

            string folder = Path.GetTempPath() + "Tastic";
            
            // Create the folder if it doesn't exist
            System.IO.Directory.CreateDirectory(folder);

            // Create a stream to save it in the temp/Tastic folder
            Stream reader = request.GetResponse().GetResponseStream();
            FileStream fileStream = new FileStream(folder + $@"\{image}", FileMode.OpenOrCreate);

            while (true)
            {
                bytesRead = reader.Read(buffer, 0, buffer.Length);

                if (bytesRead == 0)
                    break;

                fileStream.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();

            // Read the bytes from the saved file to an array
            byte[] fileData = File.ReadAllBytes(folder + $@"\{image}");

            // Binary write the bytes
            context.Response.BinaryWrite(fileData);

            stopwatch.Stop();

            System.Diagnostics.Debug.WriteLine(stopwatch.ElapsedMilliseconds);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}