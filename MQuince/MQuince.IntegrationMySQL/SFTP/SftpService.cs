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
        //IEnumerable<SftpFile> ListAllFiles(string remoteDirectory = ".");
       // void UploadFile(string localFilePath, string remoteFilePath);
        //void DownloadFile(string remoteFilePath, string localFilePath);
        //void DeleteFile(string remoteFilePath);
        bool SendFile(string fileName);

    }
    public class SftpService : ISftpService
    {
          /*  private readonly ILogger<SftpService> _logger;
            private readonly SftpConfig _config;

        public SftpService(ILogger<SftpService> logger, SftpConfig sftpConfig)
            {
                _logger = logger;
                _config = sftpConfig;
            }*/

        /*public SftpService()
        {
        }
        */
        /*public IEnumerable<SftpFile> ListAllFiles(string remoteDirectory = ".")
            {
                using var client = new SftpClient(_config.Host, _config.Port == 0 ? 22 : _config.Port, _config.UserName, _config.Password);
                try
                {
                    client.Connect();
                    return client.ListDirectory(remoteDirectory);
                }
                catch (Exception exception)
                {
                    _logger.LogError(exception, $"Failed in listing files under [{remoteDirectory}]");
                    return null;
                }
                finally
                {
                    client.Disconnect();
                }
            }
        */
            public bool SendFile(string fileName)
            {
                SftpConfig config = new SftpConfig
                {
                    Host = "192.168.0.15",
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
        /*
        public void UploadFile(string localFilePath, string remoteFilePath)
            {
                using var client = new SftpClient(_config.Host, _config.Port == 0 ? 22 : _config.Port, _config.UserName, _config.Password);
                try
                {
                    client.Connect();
                    using var s = File.OpenRead(localFilePath);
                    client.UploadFile(s, remoteFilePath);
                    _logger.LogInformation($"Finished uploading file [{localFilePath}] to [{remoteFilePath}]");
                }
                catch (Exception exception)
                {
                    _logger.LogError(exception, $"Failed in uploading file [{localFilePath}] to [{remoteFilePath}]");
                }
                finally
                {
                    client.Disconnect();
                }
            }

            public void DownloadFile(string remoteFilePath, string localFilePath)
            {
                using var client = new SftpClient(_config.Host, _config.Port == 0 ? 22 : _config.Port, _config.UserName, _config.Password);
                try
                {
                    client.Connect();
                    using var s = File.Create(localFilePath);
                    client.DownloadFile(remoteFilePath, s);
                    _logger.LogInformation($"Finished downloading file [{localFilePath}] from [{remoteFilePath}]");
                }
                catch (Exception exception)
                {
                    _logger.LogError(exception, $"Failed in downloading file [{localFilePath}] from [{remoteFilePath}]");
                }
                finally
                {
                    client.Disconnect();
                }
            }

            public void DeleteFile(string remoteFilePath)
            {
                using var client = new SftpClient(_config.Host, _config.Port == 0 ? 22 : _config.Port, _config.UserName, _config.Password);
                try
                {
                    client.Connect();
                    client.DeleteFile(remoteFilePath);
                    _logger.LogInformation($"File [{remoteFilePath}] deleted.");
                }
                catch (Exception exception)
                {
                    _logger.LogError(exception, $"Failed in deleting file [{remoteFilePath}]");
                }
                finally
                {
                    client.Disconnect();
                }
            }
        */


        
    }
}
