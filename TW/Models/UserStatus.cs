using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eUseControl.Domain.Enums;

namespace TW.Models
{
    public class UserStatus
     {
          public string Username { get; set; }
          public URole Level { get; set; }

          public bool Status { get; set; }
          public List<MProduct> Products { get; set; }
     }
}