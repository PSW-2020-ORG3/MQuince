using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Sftp.Constracts.Services
{
    public interface ISftpService
    {
        bool SendFile(string fileName);
        bool SaveFile(string fileName);

    }
}
