using MQuince.Sftp.Constracts.Services;
using MQuince.Sftp.Domain;
using Renci.SshNet;
using System;
using System.IO;

namespace MQuince.Sftp.Services
{
    public class SftpService : ISftpService
    {
        public bool SendFile(string fileName)
        {
            SftpConfig config = new SftpConfig
            {
                Host = "192.168.1.11",
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
                Host = "192.168.1.11",
                Port = 22,
                UserName = "tester",
                Password = "password"
            };
            using (var client = new SftpClient(config.Host, config.Port, config.UserName, config.Password))
            {
                // connect and log in
                client.Connect();

                if (!client.IsConnected)
                {
                    Console.WriteLine("It's not connected!");
                    return false;
                }

                using (var fileStream = new FileStream(fileName, FileMode.Create))
                {
                    client.BufferSize = 4 * 1024;
                    client.DownloadFile(Path.GetFileName(fileName), fileStream);
                }

                return true;
            }
        }
    }
}
