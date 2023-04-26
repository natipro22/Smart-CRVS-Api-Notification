﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDiv.CRVS.Domain.Entities;

namespace AppDiv.CRVS.Application.Contracts.DTOs
{
    public record UserResponseDTO
    {
        public string Id { get; set; }
        // public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        // public Guid PersonalInfoId { get; set; }
        public PersonalInfoDTO PersonalInfo { get; set; }

    }
}
