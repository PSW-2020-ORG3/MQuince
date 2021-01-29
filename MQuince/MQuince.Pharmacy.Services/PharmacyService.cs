using MQuince.Core.IdentifiableDTO;
using MQuince.Pharmacy.Contracts.DTO;
using MQuince.Pharmacy.Contracts.Repository;
using MQuince.Pharmacy.Contracts.Services;
using MQuince.Pharmacy.Domain;
using MQuince.Pharmacy.Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MQuince.Pharmacy.Services
{
	public class PharmacyService : IPharmacyService
	{
		public IPharmacyRepository _pharmacyRepository;

		public PharmacyService(IPharmacyRepository pharmacyRepository)
		{
			_pharmacyRepository = pharmacyRepository == null ? throw new ArgumentNullException(nameof(pharmacyRepository) + "is set to null") : pharmacyRepository;

		}



		public bool Delete(Guid id) => _pharmacyRepository.Delete(id);

		public IEnumerable<IdentifiableDTO<PharmacyDTO>> GetByAllParams()
			=> _pharmacyRepository.GetAll().Select(c => CreateDTOFromPharmacy(c));


		public IdentifiableDTO<PharmacyDTO> GetById(Guid api) => CreateDTOFromPharmacy(_pharmacyRepository.GetById(api));


		private IdentifiableDTO<PharmacyDTO> CreateDTOFromPharmacy(MyPharmacy pharmacy)
		{
			if (pharmacy == null) return null;

			return new IdentifiableDTO<PharmacyDTO>()
			{
				Id = pharmacy.ApiKey,
				EntityDTO = new PharmacyDTO()
				{
					ApiKey = pharmacy.ApiKey,
					Name = pharmacy.Name,
					Url = pharmacy.Url
				}

			};
		}
		private MyPharmacy CreatePharmacyFromDTO(PharmacyDTO pharmacy)
		  => new MyPharmacy(pharmacy.ApiKey, pharmacy.Name, pharmacy.Url);


		public Guid Create(PharmacyDTO entityDTO)
		{
			MyPharmacy pharmacy = CreatePharmacyFromDTO(entityDTO);
			_pharmacyRepository.Create(pharmacy);

			return pharmacy.ApiKey;
		}

		public IEnumerable<IdentifiableDTO<PharmacyDTO>> GetByAllParams(string name, string url, Guid api)
			=> _pharmacyRepository.GetByAllParams(name, url, api).Select(c => CreateDTOFromPharmacy(c));

		public void Update(PharmacyDTO entityDTO, Guid id)
		{
			_pharmacyRepository.Update(CreatePharmacyFromDTO(entityDTO));
		}

		public IEnumerable<IdentifiableDTO<PharmacyDTO>> GetAll()
		{
			try
			{
				return _pharmacyRepository.GetAll().Select(c => PharmacyMapper.MapPhamracyEntityToPharmacyIdentifierDTO(c));
			}
			catch (ArgumentNullException e)
			{
				throw new NotFoundEntityException();
			}
			catch (Exception e)
			{
				throw new NotFoundEntityException();
			}
		}


		private class NotFoundEntityException : Exception
		{
			private static readonly string _message = "Entity not found in database";
			public NotFoundEntityException() : base(_message)
			{
			}

		}

		private class InternalServerErrorException : Exception
		{
			private static readonly string _message = "Internal server error exception";
			public InternalServerErrorException() : base(_message)
			{
			}

		}

	}
}
