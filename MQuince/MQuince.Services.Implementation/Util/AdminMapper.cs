using MQuince.Entities.Users;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Services.Implementation.Util
{
    public class AdminMapper
    {
        public static IdentifiableDTO<AdminDTO> MapAdminEntityToIdentifierAdminDTO(Admin admin)
                => admin == null ? throw new ArgumentNullException()
                                        : new IdentifiableDTO<AdminDTO>()
                                        {
                                            EntityDTO = new AdminDTO()
                                            {
                                                Name = admin.Name,
                                                Surname = admin.Surname,
                                                Username = admin.Username,
                                                Password = admin.Password,
                                                Jmbg = admin.Jmbg
                                            }

                                        };


        public static IEnumerable<IdentifiableDTO<AdminDTO>> MapAdminEntityCollectionToIdentifierAdminDTOCollection(IEnumerable<Admin> admins)
                    => admins == null ? throw new ArgumentNullException()
                                         : admins.Select(entity => MapAdminEntityToIdentifierAdminDTO(entity));
    }
}
