using MQuince.Services.Contracts.DTO;
using MQuince.Services.Contracts.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.Interfaces
{
    public interface IHospitalSurveyService : IService<HospitalSurveyDTO, IdentifiableDTO<HospitalSurveyDTO>>
    {
    }
}
