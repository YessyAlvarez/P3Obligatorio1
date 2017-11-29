namespace MVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC.Models.contexto.MiContextoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MVC.Models.contexto.MiContextoContext";
        }

        protected override void Seed(MVC.Models.contexto.MiContextoContext context)
        {
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



            context.Provinces.AddOrUpdate(x => x.Id,
            new Models.Province { Id = 1, Name = "Artigas" },
            new Models.Province { Id = 2, Name = "Canelones" },
            new Models.Province { Id = 3, Name = "Cerro Largo" },
            new Models.Province { Id = 4, Name = "Colonia" },
            new Models.Province { Id = 5, Name = "Durazno" },
            new Models.Province { Id = 6, Name = "Flores" },
            new Models.Province { Id = 7, Name = "Florida" },
            new Models.Province { Id = 8, Name = "Lavalleja" },
            new Models.Province { Id = 9, Name = "Maldonado" },
            new Models.Province { Id = 10, Name = "Montevideo" },
            new Models.Province { Id = 11, Name = "Paysandú" },
           new Models.Province { Id = 12, Name = "Río Negro" },
           new Models.Province { Id = 13, Name = "Rivera" },
           new Models.Province { Id = 14, Name = "Rocha" },
           new Models.Province { Id = 15, Name = "Salto" },
           new Models.Province { Id = 16, Name = "San José" },
           new Models.Province { Id = 17, Name = "Soriano" },
           new Models.Province { Id = 18, Name = "Tacuarembó" },
           new Models.Province { Id = 19, Name = "Treinta y Tres" });


           context.SaveChanges();
        }
    }
}
