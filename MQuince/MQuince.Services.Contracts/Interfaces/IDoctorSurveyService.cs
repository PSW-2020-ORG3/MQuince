using MQuince.Services.Contracts.DTO.Communication;
using MQuince.Services.Contracts.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Contracts.Interfaces
{
    public interface IDoctorSurveyService : IService<DoctorSurveyDTO, IdentifiableDTO<DoctorSurveyDTO>>
    {
    }
}
