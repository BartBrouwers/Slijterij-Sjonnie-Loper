namespace Slijterij_Sjonnie.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Slijterij_Sjonnie.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    internal sealed class Configuration : DbMigrationsConfiguration<Slijterij_Sjonnie.Models.ApplicationDbContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        public byte[] ImageToByteArray(string imageIn)
        {

            var ImageOut = System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath(imageIn));
            return ImageOut.ToArray();
        }

        protected override void Seed(Slijterij_Sjonnie.Models.ApplicationDbContext context)
        {


            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //if (!roleManager.RoleExists("Admin"))
            //{
            //    var role = new IdentityRole("Admin");
            //    roleManager.Create(role);

            //    try
            //    {
            //        var User = userManager.FindByEmail("admin@admin.nl");
            //        userManager.AddToRole(User.Id, "Admin");
            //    }
            //    catch (System.Exception)
            //    {
            //        var User = new ApplicationUser();
            //        User.UserName = "admin@admin.nl";
            //        User.Email = "admin@admin.nl";
            //        string pwd = "admin";
            //        var checkUser = userManager.Create(User, pwd);
            //        if (checkUser.Succeeded)
            //        {
            //            userManager.AddToRole(User.Id, "Admin");
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //}


            var Whisky = new Models.Whisky
            {
                Id = 1,
                Etiket = new Models.Etiket
                {
                    Id = 1,
                    Naam = "Johhnie Walker",
                    Prijs = 18,
                    Soort = Models.Etiket.SoortWhisky.Blend,
                    AlcoholPercentage = 40,
                    ProductieGebied = "Schotland",
                    AfbeeldingPath = "~/Content/Images/johhnie_walker.png"
                },
                Aantal = 5,
                Leeftijd = DateTime.Now,
            };

            var Whisky2 = new Models.Whisky
            {
                Id = 2,
                Etiket = new Models.Etiket
                {
                    Id = 2,
                    Naam = "Highland Park",
                    Prijs = 35,
                    Soort = Models.Etiket.SoortWhisky.Blend,
                    AlcoholPercentage = 40,
                    ProductieGebied = "Schotland",
                    AfbeeldingPath = "../Content/Images/highland.png"
                },
                Aantal = 12,
                Leeftijd = DateTime.Now,
            };

            var Whisky3 = new Models.Whisky
            {
                Id = 1,
                Etiket = new Models.Etiket
                {
                    Id = 1,
                    Naam = "Sjaakie Walker",
                    Prijs = 22,
                    Soort = Models.Etiket.SoortWhisky.Blend,
                    AlcoholPercentage = 33,
                    ProductieGebied = "Schotland",
                    AfbeeldingPath = "../Content/Images/johhnie_walker.png"
                },
                Aantal = 18,
                Leeftijd = DateTime.Now,
            };

            var Reservatie = new Models.Reservering
            {
                Id = 1,
                UserId = "dd778311-4715-4014-9570-61a1de34085b",
                Aantal = 2,
                Datum = DateTime.Now,
                Whisky = Whisky
            };

            //var passwordHash = new PasswordHasher();
            //string password = passwordHash.HashPassword("admin");

            //var user = new ApplicationUser
            //{
            //    UserName = "admin@admin.nl",
            //    PasswordHash = password,
            //    PhoneNumber = "12345678911",
            //    Email = "admin@admin.nl"
      
            //};

            //context.Roles.AddOrUpdate(new IdentityRole { Id = "1", Name = "Admin", });

            //var store = new UserStore<ApplicationUser>(context);
            //var manager = new UserManager<ApplicationUser>(store);

            //manager.Create(user, "admin");
            //manager.AddToRole(user, "Admin");

            context.Reserveringen.AddOrUpdate(Reservatie);
            context.Whiskies.AddOrUpdate(Whisky);
            context.Whiskies.AddOrUpdate(Whisky2);
            context.Whiskies.AddOrUpdate(Whisky3);
            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            Etiket Etiket1 = new Etiket
            {
                Naam = "FranseWijn",
                AlcoholPercentage = 12,
                ProductieGebied = "Valencia",
                Soort = Etiket.SoortWhisky.Malt
            };
            Etiket Etiket2 = new Etiket
            {
                Naam = "NietZoFranseWijn",
                AlcoholPercentage = 5,
                ProductieGebied = "Sussex",
                Soort = Etiket.SoortWhisky.Rye
            };
            new List<Etiket> { Etiket1, Etiket2 }.ForEach(x => context.Etiketten.AddOrUpdate(x));
            context.SaveChanges();

            Whisky Whisky1 = new Whisky
            {
                Etiket = Etiket1,
                Prijs = 50,
                Aantal = 2731
            };

            Whisky Whisky2 = new Whisky
            {
                Etiket = 
            }

            Reservering Reservering1 = new Reservering
            {
                Whisky = new Whisky
                {
                    
                }
            };
        }
    }
}
