using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace AppDiv.CRVS.Application.Contracts.DTOs.BirthNotifications
{
    public class MotherInfoDTO
    {
        public Guid Id { get; set; }
        public JObject FirstName { get; set; }
        public JObject MiddleName { get; set; }
        public JObject LastName { get; set; }
        public string BirthDateEt { get; set; }
        public int Age { get; set; }
    }
}