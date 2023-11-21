using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace AppDiv.CRVS.Application.Contracts.Request;

public class AddOnlineApplication
{
    public string FullName { get; set; }
    public string Phone { get; set; }
    public JObject Content { get; set; }
}
