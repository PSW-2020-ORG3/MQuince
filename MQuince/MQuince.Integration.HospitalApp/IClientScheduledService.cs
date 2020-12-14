using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MQuince.Integration.HospitalApp
{
    public interface IClientScheduledService
    {
        Task<String> SendMessage(string name);
    }
}
