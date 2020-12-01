using MQuince.Entities.Users;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.Services.Implementation.Util
{
    public class SpecializationMapper
    {
        public static IdentifiableDTO<SpecializationDTO> MapSpecializationEntityToSpecializationIdentifierDTO(Specialization specialization)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<IdentifiableDTO<SpecializationDTO>> MapSpecializationEntityCollectionToSpecializationIdentifierDTOCollection(IEnumerable<Specialization> specializations)
        {
            throw new NotImplementedException();
        }
    }
}
