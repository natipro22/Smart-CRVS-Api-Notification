using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AppDiv.CRVS.Domain.Base;
using Newtonsoft.Json.Linq;

namespace AppDiv.CRVS.Domain.Entities.Notification;

public class OnlineApplication : BaseAuditableEntity
{
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string ContentStr { get; set; }
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
