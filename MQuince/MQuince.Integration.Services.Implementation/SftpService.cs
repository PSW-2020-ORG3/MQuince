using MQuince.Integration.Entities;
using MQuince.Integration.Services.Constracts.Interfaces;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MQuince.Integration.Services.Implementation
{
    public class SftpService : ISftpService
    {
        public bool SendFile(string fileName)
        {
            SftpConfig config = new SftpConfig
            {
                Host = "192.168.1.12",
                Port = 22,
                UserName = "tester",
                Password = "password"
            };

            using (var client = new SftpClient(config.Host, config.Port, config.UserName, config.Password))
            {
                client.Connect();
                if (client.IsConnected)
                {
                    using (var fileStream = new FileStream(fileName, FileMode.Open))
                    {
                        client.BufferSize = 4 * 1024;
                        client.UploadFile(fileStream, Path.GetFileName(fileName));
                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("It's not connected.");
                    return false;
                }
            }

        }

        public bool SaveFile(string fileName)
        {
            SftpConfig config = new SftpConfig
            {
                Host = "192.168.1.12",
                Port = 22,
                UserName = "tester",
                Password = "password"
            };
            using (var client = new SftpClient(config.Host, config.Port, config.UserName, config.Password))
            {
                // connect and log in
                client.Connect();
                if (client.IsConnected)
                {
                    using (var fileStream = new FileStream(fileName, FileMode.Create))
                    {
                        client.BufferSize = 4 * 1024;
                        client.DownloadFile(Path.GetFileName(fileName), fileStream);
                    }


                    return true;
                }
                else
                {
                    Console.WriteLine("It's not connected.");
                    return false;
                }


            }
        }
        }
}
