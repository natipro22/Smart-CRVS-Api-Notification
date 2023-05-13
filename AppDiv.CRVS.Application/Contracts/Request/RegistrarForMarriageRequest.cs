using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDiv.CRVS.Application.Contracts.DTOs;

namespace AppDiv.CRVS.Application.Contracts.Request
{
    public class RegistrarForMarriageRequest : AddRegistrarRequest
    {
        public virtual GroomInfoDTO RegistrarInfo { get; set; }
    }
}