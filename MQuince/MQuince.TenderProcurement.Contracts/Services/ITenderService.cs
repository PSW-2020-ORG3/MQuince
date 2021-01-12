using MQuince.Core.Contracts;
using MQuince.Core.IdentifiableDTO;
using MQuince.TenderProcurement.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQuince.TenderProcurement.Contracts.Services
{
    public interface ITenderService : IService<TenderDTO, IdentifiableDTO<TenderDTO>>
    {
    }
}