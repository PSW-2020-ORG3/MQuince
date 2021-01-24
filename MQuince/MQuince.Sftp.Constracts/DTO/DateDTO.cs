using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Sftp.Constracts.DTO
{
    public class DateDTO
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public DateDTO(DateTime from, DateTime to)
        {
            From = from;
            To = to;

        }

    }
}
