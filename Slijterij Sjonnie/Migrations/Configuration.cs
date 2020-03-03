namespace Slijterij_Sjonnie.Migrations
{
    using Slijterij_Sjonnie.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Slijterij_Sjonnie.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Slijterij_Sjonnie.Models.ApplicationDbContext context)
        {
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
