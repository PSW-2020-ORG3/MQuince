using MQuince.Core.Contracts;
using MQuince.Core.IdentifiableDTO;
using MQuince.Pharmacy.Contracts.DTO;
using System;
using System.Collections.Generic;

namespace MQuince.Pharmacy.Contracts.Services
{
	public interface IPharmacyService : IService<PharmacyDTO, IdentifiableDTO<PharmacyDTO>>
	{
		IEnumerable<IdentifiableDTO<PharmacyDTO>> GetByAllParams(string name, string url, Guid api);

	}
}
