using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ylesane2.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<WorkDay> WorkDays { get; set; }

        public DataBaseContext() : base("IluSalongDB1")
        {
            if (!Database.Exists())
                Database.Create();

            //if (Roles.Where(x => x.Name == "User").FirstOrDefault() == null)
            //{
            //    Roles.Add(new Role()
            //    {
            //        Name = "User",
            //        AccessLevel = 1
            //    });

            //    Roles.Add(new Role()
            //    {
            //        Name = "Admin",
            //        AccessLevel = 2
            //    });
            //    SaveChanges();
            //}

            //if (Users.Where(x => x.Email == "admin@gmail.com").FirstOrDefault() == null)
            //{
            //    Users.Add(new User()
            //    {
            //        Email = "admin@gmail.com",
            //        Password = Hash.ComputeSha256Hash("admin"),
            //        Name = "Marko",
            //        SecondName = "Mirko",
            //        RoleId = 2,
            //        PhoneNumber = "37255544444",
            //    });

            //    Users.Add(new User()
            //    {
            //        Email = "dk@gmail.com",
            //        Password = Hash.ComputeSha256Hash("admin"),
            //        Name = "Daniil",
            //        SecondName = "Koroljov",
            //        RoleId = 1,
            //        PhoneNumber = "372555555",
            //    });

            //}

            //Products.Add(new Product()
            //{
            //    Name = "Product",
            //    Description = "Description",
            //    Price = (20),

            //});

            SaveChanges();
        }
        
    }

    //public class UserDbInitializer : DropCreateDatabaseAlways<DataBaseContext>
    //{
    //    protected override void Seed(DataBaseContext db)
    //    {
    //        db.Roles.Add(new Role { Id = 1, Name = "admin" });
    //        db.Roles.Add(new Role { Id = 2, Name = "user" });
    //        db.Users.Add(new User
    //        {
    //            Id = 1,
    //            Name = "Admin",
    //            PhoneNumber = "3725555555",
    //            Email = "admin@gmail.com",
    //            Password = "admin",
    //            RoleId = 1
    //        });
    //        base.Seed(db);
    //    }
    //}
}