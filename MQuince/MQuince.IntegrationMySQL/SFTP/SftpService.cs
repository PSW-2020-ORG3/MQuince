using System;
using System.Collections.Generic;
using System.Text;


using System.IO;
using Microsoft.Extensions.Logging;
using Renci.SshNet;
using Renci.SshNet.Sftp;


namespace MQuince.IntegrationMySQL.STFP
{

    public interface ISftpService
    {
        bool SendFile(string fileName);

    }
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

            using (var client = new SftpClient(config.Host,config.Port,config.UserName,config.Password))
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
    }
}
