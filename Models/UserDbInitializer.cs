using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Helpers; //crypto

namespace SoloduhaMVC.Models
{
    public class UserDbInitializer : DropCreateDatabaseAlways<UserDbContext>
    {
        protected override void Seed(UserDbContext context)
        {
            Role roleAdmin = new Role { Name = "admin" };
            Role roleUser = new Role { Name = "user" };
            context.Roles.AddRange(new List<Role> { roleAdmin, roleUser });
            context.SaveChanges();

            User u1 = new User { Login = "newadm", Password = "adminadmin", Role = roleAdmin };
            context.Users.Add(u1);
            context.SaveChanges();
            
            base.Seed(context);
        }
    }
}