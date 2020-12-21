using MQuince.Entities;
using MQuince.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.DTO.Communication
{
    public class NotificationDTO
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }

        public List<Guid> UserId;

        public Guid CreatedByStaffId;
    }
}
