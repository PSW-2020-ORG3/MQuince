using MQuince.Core.Contracts;
using MQuince.Core.IdentifiableDTO;
using MQuince.Sftp.Constracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Sftp.Constracts.Services
{
    public interface IMedicationsConsumptionService : IService<MedicationsConsumptionDTO, IdentifiableDTO<MedicationsConsumptionDTO>>
    {
        IEnumerable<IdentifiableDTO<MedicationsConsumptionDTO>> GetConsumptionBetweenDates(DateTime from, DateTime to);
        void GeneratePdf(DateDTO dto);


    }
}
