using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WinBeyazEsya.Infrastructure.Persistence;

namespace TestSeeder
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WinBeyazEsyaMasterContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=WinBeyazEsya_Master;Trusted_Connection=True;Encrypt=False;");

            using (var context = new WinBeyazEsyaMasterContext(optionsBuilder.Options))
            {
                Console.WriteLine("Checking DB...");
                var rolesCount = context.Roles.IgnoreQueryFilters().Count();
                Console.WriteLine("Roles count: " + rolesCount);
                
                var usersCount = context.Users.IgnoreQueryFilters().Count();
                Console.WriteLine("Users count: " + usersCount);
                
                var users = context.Users.IgnoreQueryFilters().ToList();
                foreach(var u in users) {
                    Console.WriteLine("User: " + u.Code + " - IsDeleted: " + u.IsDeleted);
                }

                var roles = context.Roles.IgnoreQueryFilters().ToList();
                foreach(var r in roles) {
                    Console.WriteLine("Role: " + r.RoleName + " - IsDeleted: " + r.IsDeleted);
                }
            }
        }
    }
}

