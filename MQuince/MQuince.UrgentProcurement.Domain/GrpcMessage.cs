using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.UrgentProcurement.Domain
{
    public class GrpcMessage
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string Quantity { get; set; }

        public GrpcMessage(string name, string status)
        {
            this.Name = name;
            this.Status = status;
        }
    }
}
