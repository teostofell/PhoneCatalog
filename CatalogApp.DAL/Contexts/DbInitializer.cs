using CatalogApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace CatalogApp.DAL.Contexts
{
    public class DbInitializer : DropCreateDatabaseAlways<CatalogContext>
    {
        protected override void Seed(CatalogContext context)
        {
            City c1 = new City() { Name = "Minsk", Slug = "minsk" };
            City c2 = new City() { Name = "Pinsk", Slug = "pinsk" };
            City c3 = new City() { Name = "Brest", Slug = "brest" };

            context.Cities.AddRange(new List<City>() { c1, c2, c3 });

            Brand b1 = new Brand() { Name = "Samsung", Slug = "samsung" };
            Brand b2 = new Brand() { Name = "Apple", Slug = "apple" };
            Brand b3 = new Brand() { Name = "LG", Slug = "lg" };
            Brand b4 = new Brand() { Name = "Sony", Slug = "sony" };

            context.Brands.AddRange(new List<Brand>() { b1, b2, b3, b4 });


            OS os1 = new OS() { Name = "Android", Slug="android" };
            OS os2 = new OS() { Name = "IOS", Slug="ios" };
            OS os3 = new OS() { Name = "Windows Mobile", Slug = "windows-mobile" };

            context.OperatingSystems.AddRange(new List<OS>() { os1, os2, os3 });


            ScreenResolution sr1 = new ScreenResolution() { Height = 1920, Width = 1080, Name = "Full HD" };
            ScreenResolution sr2 = new ScreenResolution() { Height = 1280, Width = 768, Name = "HD" };

            context.ScreenResolutions.AddRange(new List<ScreenResolution>() { sr1, sr2 });

            Phone p1 = new Phone() { Model = "A5", Brand = b1, Battery = 2100, Fingerprint = true, OS = os1, Price = 300M, ScreenSize = 5.2F, ScreenResolution = sr1, ReleaseDate = DateTime.Now, Photo= "//content2.onliner.by/catalog/device/header/6920a71561c4c9c1b63aae084aa9b6b3.jpeg" };
            Phone p2 = new Phone() { Model = "A7", Brand = b1, Battery = 3100, Fingerprint = true, OS = os1, Price = 500M, ScreenSize = 6.1F, ScreenResolution = sr1, ReleaseDate = DateTime.Now, Photo= "//content2.onliner.by/catalog/device/header/0915a88b6868873a178b0781312f83c9.jpeg" };
            Phone p3 = new Phone() { Model = "G7", Brand = b3, Battery = 2700, Fingerprint = true, OS = os1, Price = 800M, ScreenSize = 5.5F, ScreenResolution = sr1, ReleaseDate = DateTime.Now, Photo= "//content2.onliner.by/catalog/device/header/9fe6b436edc0a720455c002f1b674af7.jpeg" };
            Phone p4 = new Phone() { Model = "A5", Brand = b1, Battery = 2100, Fingerprint = true, OS = os1, Price = 300M, ScreenSize = 5.2F, ScreenResolution = sr1, ReleaseDate = DateTime.Now, Photo = "//content2.onliner.by/catalog/device/header/6920a71561c4c9c1b63aae084aa9b6b3.jpeg" };
            Phone p5 = new Phone() { Model = "A7", Brand = b1, Battery = 3100, Fingerprint = true, OS = os1, Price = 500M, ScreenSize = 6.1F, ScreenResolution = sr1, ReleaseDate = DateTime.Now, Photo = "//content2.onliner.by/catalog/device/header/0915a88b6868873a178b0781312f83c9.jpeg" };
            Phone p6 = new Phone() { Model = "G7", Brand = b3, Battery = 2700, Fingerprint = true, OS = os1, Price = 800M, ScreenSize = 5.5F, ScreenResolution = sr1, ReleaseDate = DateTime.Now, Photo = "//content2.onliner.by/catalog/device/header/9fe6b436edc0a720455c002f1b674af7.jpeg" };
            Phone p7 = new Phone() { Model = "A5", Brand = b1, Battery = 2100, Fingerprint = true, OS = os1, Price = 300M, ScreenSize = 5.2F, ScreenResolution = sr1, ReleaseDate = DateTime.Now, Photo = "//content2.onliner.by/catalog/device/header/6920a71561c4c9c1b63aae084aa9b6b3.jpeg" };
            Phone p8 = new Phone() { Model = "A7", Brand = b1, Battery = 3100, Fingerprint = true, OS = os1, Price = 500M, ScreenSize = 6.1F, ScreenResolution = sr1, ReleaseDate = DateTime.Now, Photo = "//content2.onliner.by/catalog/device/header/0915a88b6868873a178b0781312f83c9.jpeg" };
            Phone p9 = new Phone() { Model = "G7", Brand = b3, Battery = 2700, Fingerprint = true, OS = os1, Price = 800M, ScreenSize = 5.5F, ScreenResolution = sr1, ReleaseDate = DateTime.Now, Photo = "//content2.onliner.by/catalog/device/header/9fe6b436edc0a720455c002f1b674af7.jpeg" };
            Phone p10 = new Phone() { Model = "A5", Brand = b1, Battery = 2100, Fingerprint = true, OS = os1, Price = 300M, ScreenSize = 5.2F, ScreenResolution = sr1, ReleaseDate = DateTime.Now, Photo = "//content2.onliner.by/catalog/device/header/6920a71561c4c9c1b63aae084aa9b6b3.jpeg" };
            Phone p11 = new Phone() { Model = "A7", Brand = b1, Battery = 3100, Fingerprint = true, OS = os1, Price = 500M, ScreenSize = 6.1F, ScreenResolution = sr1, ReleaseDate = DateTime.Now, Photo = "//content2.onliner.by/catalog/device/header/0915a88b6868873a178b0781312f83c9.jpeg" };
            Phone p12 = new Phone() { Model = "G7", Brand = b3, Battery = 2700, Fingerprint = true, OS = os1, Price = 800M, ScreenSize = 5.5F, ScreenResolution = sr1, ReleaseDate = DateTime.Now, Photo = "//content2.onliner.by/catalog/device/header/9fe6b436edc0a720455c002f1b674af7.jpeg" };

            context.Phones.AddRange(new List<Phone>() { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12 });
        }
    }
}