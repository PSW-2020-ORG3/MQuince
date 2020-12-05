using MQuince.Integration.Services.Constracts.DTO;
using MQuince.Integration.Services.Constracts.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Integration.Services.Constracts.Interfaces
{
    public interface IMedicationsConsumptionService : IService<MedicationsConsumptionDTO, IdentifiableDTO<MedicationsConsumptionDTO>>
    {
        IEnumerable<IdentifiableDTO<MedicationsConsumptionDTO>> GetConsumptionBetweenDates(DateTime from, DateTime to);
        void GeneratePdf(DateDTO dto);


    }
}
