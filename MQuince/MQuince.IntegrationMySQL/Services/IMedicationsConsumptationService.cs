using MQuince.IntegrationMySQL.DTO;
using MQuince.IntegrationMySQL.Pharmacy;
using System;
using System.Collections.Generic;

namespace MQuince.IntegrationMySQL.Services
{
    public interface IMedicationsConsumptionService : IService<MedicationsConsumptionDTO, IdentifiableDTO<MedicationsConsumptionDTO>>
    {
        IEnumerable<MedicationsConsumption> getConsumptionBetweenDates(DateTime from, DateTime to);


    }
}