using MQuince.Core.IdentifiableDTO;
using MQuince.StafManagement.Contracts.DTO;
using MQuince.StafManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.StafManagement.Application.Services.Util
{
    public class SpecializationMapper
    {
        public static IdentifiableDTO<SpecializationDTO> MapSpecializationEntityToSpecializationIdentifierDTO(Specialization specialization)
            => specialization == null ? throw new ArgumentNullException()
                                      : new IdentifiableDTO<SpecializationDTO>
                                      {
                                          Id= specialization.Id,
                                          EntityDTO= new SpecializationDTO() { Name= specialization.Name }
                                      };

        public static IEnumerable<IdentifiableDTO<SpecializationDTO>> MapSpecializationEntityCollectionToSpecializationIdentifierDTOCollection(IEnumerable<Specialization> specializations)
            => specializations == null ? throw new ArgumentNullException()
                                      : specializations.Select(entity => MapSpecializationEntityToSpecializationIdentifierDTO(entity));
    }
}
