using MQuince.IntegrationMySQL.Pharmacy;
using System;
using System.Collections.Generic;

namespace MQuince.IntegrationMySQL.Repository
{
    public interface IMedicationsConsumptionRepository : IRepository<MedicationsConsumption>
    {
        //IEnumerable<MedicationsConsumption> getConsumptionBetweenDates(DateTime from, DateTime to);

    }
}