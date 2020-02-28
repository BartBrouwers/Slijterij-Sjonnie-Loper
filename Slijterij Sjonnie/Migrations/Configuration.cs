namespace Slijterij_Sjonnie.Migrations
{
    using Slijterij_Sjonnie.Models;
    using System;
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

            var Reservatie = new Models.Reservering
            {
                Id = 1,
                UserId = "dd778311-4715-4014-9570-61a1de34085b",
                Aantal = 2,
                Datum = DateTime.Now,
                Whisky = Whisky
            };

            context.Whiskies.AddOrUpdate(Whisky);
            context.Whiskies.AddOrUpdate(Whisky2);
            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            
        }
    }
}
