using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Data.Entity;

using MyCMS.Domain.Entities;

namespace MyCMS.Data
{
    public class ContextInitializer /*: DropCreateDatabaseAlways<DatabaseContext>*/ : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            var arts = new List<Article>
            {
                new Article { Title = "This title can be better", Rewrite = "aa", Body = "<p>So effectively you can run aspnet_regsql against your “Model” database in your development system and then each time Entity Framework creates a new database, it will inherit aspnet Application Service tables!</p>", DateCreated = DateTime.Now, Published = true }
            };
            arts.ForEach(l => context.Articles.Add(l));
            context.SaveChanges();

            //TODO: Esto habria que hacerlo a traves de servicios de dominio y librarse de la dependencia 
            //de System.Web
            Membership.CreateUser("root", "cmsadmin");
            
            //Roles.CreateRole("admin");
            //Roles.AddUsersToRole(new[] { "root" }, "admin");  
        }
    }
}