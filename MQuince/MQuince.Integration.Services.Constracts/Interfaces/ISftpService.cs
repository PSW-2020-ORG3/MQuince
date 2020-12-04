using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Integration.Services.Constracts.Interfaces
{
    public interface ISftpService
    {
        bool SendFile(string fileName);

    }
}
