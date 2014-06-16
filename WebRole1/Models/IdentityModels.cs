using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using WebRole1.Interface;

namespace WebRole1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class UserManager : UserManager<WebRole1.Interface.IdentityUser>
    {
        public UserManager()
            : base(new UserStore(new SqlDatabase()))
        {
        }
    }

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

    }
}

