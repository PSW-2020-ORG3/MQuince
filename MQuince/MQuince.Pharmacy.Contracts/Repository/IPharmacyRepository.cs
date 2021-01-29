using MQuince.Core.Contracts;
using MQuince.Pharmacy.Domain;
using System;
using System.Collections.Generic;

namespace MQuince.Pharmacy.Contracts.Repository
{
	public interface IPharmacyRepository : IRepository<MyPharmacy>
	{
		IEnumerable<MyPharmacy> GetByAllParams(string name, string url, Guid api);

	}
}
