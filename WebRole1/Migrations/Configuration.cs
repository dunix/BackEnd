namespace WebRole1.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebRole1.Interface;

    internal sealed class Configuration : DbMigrationsConfiguration<WebRole1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebRole1.Models.ApplicationDbContext context)
        {
            //var roleManager = new RoleManager<WebRole1.Interface.IdentityUser>(new RoleStore(new SqlDatabase()));
            //var roleManager = new RoleManager<WebRole1.Interface.IdentityUser>(context);

            //var userStore = new WebRole1.Interface.UserStore<WebRole1.Interface.IdentityUser>(context);
            //var userManager = new UserManager<IdentityUser>(userStore);
            //var user = new IdentityUser { UserName = "instructor@instructor.com" };

            //userManager.Create(user, "password");
            //roleManager.Create(WebRole1.Interface.IdentityRole { Name = "instructor" });
            //userManager.AddToRole(user.Id, "instructor");
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
