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
            Brand b5 = new Brand() { Name = "Xiaomi", Slug = "xiaomi" };
            Brand b6 = new Brand() { Name = "Huawei", Slug = "huawei " };

            context.Brands.AddRange(new List<Brand>() { b1, b2, b3, b4, b5, b6 });


            OS os1 = new OS() { Name = "Android", Slug = "android" };
            OS os2 = new OS() { Name = "IOS", Slug = "ios" };
            OS os3 = new OS() { Name = "Windows Mobile", Slug = "windows-mobile" };

            context.OperatingSystems.AddRange(new List<OS>() { os1, os2, os3 });


            ScreenResolution sr1 = new ScreenResolution() { Height = 1920, Width = 1080, Name = "Full HD" };
            ScreenResolution sr2 = new ScreenResolution() { Height = 1280, Width = 768, Name = "HD" };

            context.ScreenResolutions.AddRange(new List<ScreenResolution>() { sr1, sr2 });

            Phone p1 = new Phone() { Model = "Redmi 5 Plus", Slug = "redmi5p32", Brand = b5, Battery = 4000, Fingerprint = true, OS = os1, Price = 410M, ScreenSize = 6F, ScreenResolution = sr1, ReleaseDate = DateTime.Now, Photo = "//content2.onliner.by/catalog/device/header/36a93587166940725b538d02c23a6b2c.jpeg" };
            Phone p2 = new Phone() { Model = "iPhone X", Slug = "iphonex", Brand = b2, Battery = 2716, Fingerprint = false, OS = os2, Price = 2500M, ScreenSize = 5.8F, ScreenResolution = sr1, ReleaseDate = DateTime.Now, Photo = "//content2.onliner.by/catalog/device/header/a83458571f2c39fc9c435bd1116b4876.jpeg" };
            Phone p3 = new Phone() { Model = "P20", Slug = "hp20", Brand = b6, Battery = 3400, Fingerprint = true, OS = os1, Price = 1600M, ScreenSize = 5.8F, ScreenResolution = sr1, ReleaseDate = DateTime.Now, Photo = "//content2.onliner.by/catalog/device/header/8c96ef80b69f9e3f3ea0153eb628ca81.jpeg" };
            Phone p4 = new Phone() { Model = "iPhone 7", Slug = "iphone732", Brand = b2, Battery = 1960, Fingerprint = true, OS = os2, Price = 1390M, ScreenSize = 4.7F, ScreenResolution = sr1, ReleaseDate = DateTime.Now, Photo = "//content2.onliner.by/catalog/device/header/0ab0b43eb38b5767ea29c4509f0a9d3b.jpeg" };
            Phone p5 = new Phone() { Model = "Galaxy S8", Slug = "galaxys8", Brand = b1, Battery = 3000, Fingerprint = true, OS = os1, Price = 1370M, ScreenSize = 5.8F, ScreenResolution = sr1, ReleaseDate = DateTime.Now, Photo = "//content2.onliner.by/catalog/device/header/272d80e5c1b51824c5034a0dffb29254.jpeg" };
            Phone p6 = new Phone() { Model = "Galaxy S9", Slug = "galaxys9", Brand = b1, Battery = 3000, Fingerprint = true, OS = os1, Price = 1850M, ScreenSize = 5.8F, ScreenResolution = sr1, ReleaseDate = DateTime.Now, Photo = "//content2.onliner.by/catalog/device/header/198eab8de1166942eff6c394f2ca8980.jpeg" };
            Phone p7 = new Phone() { Model = "Redmi Note 5", Slug = "note5pro", Brand = b5, Battery = 4000, Fingerprint = true, OS = os1, Price = 699M, ScreenSize = 6F, ScreenResolution = sr1, ReleaseDate = DateTime.Now, Photo = "//content2.onliner.by/catalog/device/header/5bd9331be19e40399301151fb6dc347b.jpeg" };
            Phone p8 = new Phone() { Model = "Redmi 4X", Slug = "redmi4x", Brand = b5, Battery = 4100, Fingerprint = true, OS = os1, Price = 285M, ScreenSize = 5F, ScreenResolution = sr1, ReleaseDate = DateTime.Now, Photo = "//content2.onliner.by/catalog/device/header/44c42062fcc6be99bdce2350506f9ce6.jpeg" };
            Phone p9 = new Phone() { Model = "Mate 10 Lite", Slug = "mate10lite", Brand = b6, Battery = 3340, Fingerprint = true, OS = os1, Price = 620M, ScreenSize = 5.9F, ScreenResolution = sr1, ReleaseDate = DateTime.Now, Photo = "//content2.onliner.by/catalog/device/header/c3e2b364b63e368c6d0a3b81d8e512b0.jpeg" };
            Phone p10 = new Phone() { Model = "P Smart", Slug = "psmart", Brand = b6, Battery = 3000, Fingerprint = true, OS = os1, Price = 499M, ScreenSize = 5.65F, ScreenResolution = sr1, ReleaseDate = DateTime.Now, Photo = "//content2.onliner.by/catalog/device/header/26cdb2e51cfe95def27a56b4b8f13ad5.jpeg" };
            Phone p11 = new Phone() { Model = "A7", Slug = "galaxya7", Brand = b1, Battery = 3100, Fingerprint = true, OS = os1, Price = 500M, ScreenSize = 6.1F, ScreenResolution = sr1, ReleaseDate = DateTime.Now, Photo = "//content2.onliner.by/catalog/device/header/0915a88b6868873a178b0781312f83c9.jpeg" };
            Phone p12 = new Phone() { Model = "G6", Slug = "lgg6", Brand = b3, Battery = 3300, Fingerprint = true, OS = os1, Price = 1030M, ScreenSize = 5.7F, ScreenResolution = sr1, ReleaseDate = DateTime.Now, Photo = "//content2.onliner.by/catalog/device/header/9fe6b436edc0a720455c002f1b674af7.jpeg" };

            context.Phones.AddRange(new List<Phone>() { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12 });


            Photo ph1 = new Photo() { Phone = p1, Path = "https://shop.velcom.by/ru/images/phones/404x600px_face_Xiaomi_5_Plus-Blue.png" };
            Photo ph2 = new Photo() { Phone = p2, Path = "https://shop.velcom.by/ru/images/phones/404x600_face(26).png" };
            Photo ph3 = new Photo() { Phone = p3, Path = "https://shop.velcom.by/ru/images/phones/404x600px_front_Huawei_P20-(Black).png" };
            Photo ph4 = new Photo() { Phone = p4, Path = "https://shop.velcom.by/ru/images/phones/404x600_7_face.png" };
            Photo ph5 = new Photo() { Phone = p5, Path = "https://shop.velcom.by/ru/images/phones/400x600_Samsung-S8_face.png" };

            Photo ph6 = new Photo() { Phone = p6, Path = "https://ss7.vzw.com/is/image/VerizonWireless/SAMSUNG_Galaxy_S9_Plus_Blue?$png8alpha256$&hei=410" };
            Photo ph61 = new Photo() { Phone = p6, Path = "https://ss7.vzw.com/is/image/VerizonWireless/SAMSUNG_Galaxy_S9_Plus_Black_Back?$png8alpha256$&hei=410" };
            Photo ph62 = new Photo() { Phone = p6, Path = "https://ss7.vzw.com/is/image/VerizonWireless/SAMSUNG_Galaxy_S9_Plus_Black_Right?$png8alpha256$&hei=410" };
            Photo ph63 = new Photo() { Phone = p6, Path = "https://ss7.vzw.com/is/image/VerizonWireless/SAMSUNG_Galaxy_S9_Plus_Black_Left?$png8alpha256$&hei=410" };

            Photo ph7 = new Photo() { Phone = p7, Path = "https://shop.velcom.by/ru/images/phones/404x600_face_xiaomi_note_4.png" };
            Photo ph8 = new Photo() { Phone = p8, Path = "https://shop.velcom.by/ru/images/phones/404x600px_big-face-Xiaomi-Redmi4X.png" };
            Photo ph9 = new Photo() { Phone = p9, Path = "https://shop.velcom.by/ru/images/phones/mate_10lite_404x600_face.png" };
            Photo ph10 = new Photo() { Phone = p10, Path = "https://shop.velcom.by/ru/images/phones/404x600px_face_Huawei-P-smart-Blue.png" };
            Photo ph11 = new Photo() { Phone = p11, Path = "https://shop.velcom.by/ru/images/phones/404x600_face_Samsung_Galaxy_A7__2017.png" };
            Photo ph12 = new Photo() { Phone = p12, Path = "https://avatars.mds.yandex.net/get-mpic/96484/img_id7311550780281291059/orig" };

            context.Photos.AddRange(new List<Photo>() { ph1, ph2, ph3, ph4, ph5, ph6, ph61, ph62, ph63, ph7, ph8, ph9, ph10, ph11, ph12 });
        }
    }
}