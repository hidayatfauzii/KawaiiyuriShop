namespace ElfsLeatherStore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using System.Collections.Generic;
    using ElfsLeatherStore.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<ElfsLeatherStore.Models.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ElfsLeatherStore.Models.StoreContext context)
        {
            List<Supplier> dataSupplier = new List<Supplier>
            {
                new Supplier {Name="PT. Royal Oriental Raplastex",Address="Jl. Kalisoka No.45 Surabaya",Telp=0271458542,Email="royalorientex@gmail.com"},
                new Supplier {Name="PT. Material Kulit",Address="Jl. Penumping No.50 Bandung",Telp=0271545685,Email="materialkulit@yahoo.com"},
                new Supplier {Name="PT. Indo Trading",Address="Jl. Adi Sucipto No.45 Yogyakarta",Telp=0271489638,Email="indotrading@gmail.com"},
                new Supplier {Name="PT. Indo Store Leather",Address="Jl. Honggowongso No.60 Jakarta",Telp=0271669887,Email="indostoreleather@yahoo.co.id"}
            };
            dataSupplier.ForEach(a => context.Suppliers.AddOrUpdate(a));
            context.SaveChanges();

            List<Category> dataCategory = new List<Category>
            {
                new Category{Name="Dompet",Description="Dompet Kulit Branded"},
                new Category{Name="Tas",Description="Tas Kulit Branded"},
                new Category{Name="Sepatu",Description="Sepatu Kulit Branded"},
                new Category{Name="Sabuk",Description="Sabuk Kulit Branded"},

            };
            dataCategory.ForEach(c => context.Categories.AddOrUpdate(c));
            context.SaveChanges();

            List<Product> dataProduct = new List<Product>
            {
                new Product{SupplierId=1,CategoryId=1,ProductName="Rip Curl",
                Description="Dompet kulit Slim and Stylish dengan menampilkan desain bi-fold.", Color="Black",Material="Kulit Sintetis",
                Price=399000,Stock="Ready"},
                new Product{SupplierId=2,CategoryId=2,ProductName="Pierre Cardin",
                Description="Tas berdesain simpel cocok untuk pecinta gaya klasik.", Color="Brown",Material="Genuine Leather",
                Price=3999000,Stock="Ready"},
                new Product{SupplierId=3,CategoryId=3,ProductName="Dr. Kevin",
                Description="Boots berdesain casual dengan material berkualitas.", Color="Dark Brown",Material="Genuine Leather",
                Price=2099000,Stock="Ready"},
                new Product{SupplierId=4,CategoryId=4,ProductName="Adobree Mens Belts",
                Description="Mens Belts menampilkan desain yang sleek dengan tekstur untuk memberi kesan berkelas.", Color="Black",Material="Kulit Sintetis",
                Price=249500,Stock="Ready"}
            };
            dataProduct.ForEach(b => context.Products.AddOrUpdate(b));
            context.SaveChanges();

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
