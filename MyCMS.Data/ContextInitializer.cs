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

            string p1 = "<p>Un jugete para mi sitio web personal</p>";
            string p2 = "<p>El objetivo primario de este pequeño desarrollo es servir como gestor de contenido para un sitio web que hospeda un colección de artículos sobre desarrollo de software. Paralelamente pretendo hacer uso de arquitecturas y herramientas que son de mi interés en este momento: Arquitectura N-Capas, Diseño orientado a dominio, Inyección de dependencias, TDD, etc... con el fin de profundizar en ellas y aprender mediante la experimentación.</p>";
            var arts = new List<Article>
            {
                new Article { Title = "¡Bienvenido a YAM-CMS!", Rewrite = "bienvenido-a-yam-cms", Body = p1 + "\r\n" + p2, DateCreated = DateTime.Now, Published = true }
            };
            arts.ForEach(l => context.Articles.Add(l));
            context.SaveChanges();

            var mainMenu = new Menu()
            {
                Column = "right",
                Order = 0,
                Title = "[Menú]",
                Items = new List<MenuItem>
                {
                    new MenuItem { Title = "Inicio", Url = "~/" },
                    new MenuItem { Title = "Archivo", Url = "~/archivo" },
                    new MenuItem { Title = "Profile", Url = "~/profile" }

                }
            };

            context.Menus.Add(mainMenu);
            context.SaveChanges();

            //TODO: Esto habria que hacerlo a traves de servicios de dominio y librarse de la dependencia 
            //de System.Web
            if (Membership.GetUser("root") == null)
            {
                Membership.CreateUser("root", "cmsadmin");

                //Roles.CreateRole("admin");
                //Roles.AddUsersToRole(new[] { "root" }, "admin");  
            }
        }
    }
}