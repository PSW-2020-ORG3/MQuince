using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Integration.Entities
{
    public class GrpcMessage
    {
        public string name { get; set; }
        public string status { get; set; }

        public GrpcMessage(string name, string status)
        {
            this.name = name;
            this.status = status;
        }
    }
}
