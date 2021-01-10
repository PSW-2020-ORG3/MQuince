﻿using MQuince.Entities.MedicalRecords;
using MQuince.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Entities.Users
{
    public class Patient : User
    {
        public bool Guest { get; set; }
        public Guid? PersonalDoctor { get; set; }

    }
}