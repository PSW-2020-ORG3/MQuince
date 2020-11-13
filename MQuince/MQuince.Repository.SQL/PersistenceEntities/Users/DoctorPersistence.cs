using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MQuince.Repository.SQL.PersistenceEntities.Users
{
    [Table("Doctor")]
    public class DoctorPersistence
    {
        [Key]
        public Guid Id { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public string Picture { get; set; }
        public int PictureNumber { get; set; }
        public string Biography { get; set; }
        [ForeignKey("SpecializationId")]
        public List<Guid> SpecializationId { get; set; }
        [ForeignKey("WorkRoomId")]
        public Guid WorkRoomId { get; set; }
        [ForeignKey("WorkPlaceId")]
        public Guid WorkPlaceId { get; set; }
    }
}
