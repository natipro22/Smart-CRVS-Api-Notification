using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AppDiv.CRVS.Domain.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AppDiv.CRVS.Domain.Entities.Notification;

public class OnlineApplication : BaseAuditableEntity
{
    public string FullNameStr { get; set; }
    public string Phone { get; set; }
    public string? ApplicationCode { get; set; }
    public string EventType { get; set; }
    public string ContentStr { get; set; }

    [NotMapped]
    public JObject FullName 
    {
        get
        {
            return JsonConvert.DeserializeObject<JObject>(string.IsNullOrEmpty(FullNameStr) ? "{}" : FullNameStr);
        }
        set
        {
            FullNameStr = value?.ToString();
        }
    }
    [NotMapped]
    public JObject Content 
    {
        get
        {
            return JObject.Parse(ContentStr ?? "{}");
        }
        set
        {
            ContentStr = value.ToString();
        }
    }
    
}
