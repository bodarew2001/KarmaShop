using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.DBModel
{
     public class UserContext : DbContext
     {
          public UserContext() : base("name=eUseControl") // connectionstring name define in your web.config
          {
          }
          public virtual DbSet<UDbTable> Users { get; set; }

          public System.Data.Entity.DbSet<eUseControl.Domain.Entities.User.UserMinimal> UserMinimals { get; set; }
     }
}
