using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace AppDiv.CRVS.Application.Contracts.DTOs;

public class OnlineApplicationDTO
{
    public Guid Id { get; set; }
    public JObject FullName { get; set; }
    public string Phone { get; set; }
    public string EventType { get; set; }
    public JObject Content { get; set; }
}
