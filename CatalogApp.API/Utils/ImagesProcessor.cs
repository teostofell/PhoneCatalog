using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

namespace CatalogApp.API.Utils
{
    public static class ImagesProcessor
    {
        public static string GetPhoneThumbnail(string base64, string filename, Size thumbSize)
        {
            byte[] bytes;

            try
            {
                bytes = Convert.FromBase64String(base64);
            }
            catch(Exception e)
            {
                return base64;
            }

            using (Image imageFile = Image.FromStream(new MemoryStream(bytes)))
            {
                string root = HttpContext.Current.Server.MapPath("~/Images/Thumb"); 

                Image thumbnail = (Image)(new Bitmap(imageFile, thumbSize));
                thumbnail.Save($"{root}/{filename}", ImageFormat.Png);

                return $"~/Images/Thumb/{filename}";
            }
        }

        public static string GetPhoneImage(string base64, string filename, Size thumbSize)
        {
            byte[] bytes;

            try
            {
                bytes = Convert.FromBase64String(base64);
            }
            catch (Exception e)
            {
                return base64;
            }

            using (Image imageFile = Image.FromStream(new MemoryStream(bytes)))
            {
                string root = HttpContext.Current.Server.MapPath("~/Images/Gallery");

                Image thumbnail = (Image)(new Bitmap(imageFile, thumbSize));
                thumbnail.Save($"{root}/{filename}", ImageFormat.Png);

                return $"~/Images/Gallery/{filename}";
            }
        }

        public static string GetUserAvatar(string base64, string filename, Size thumbSize)
        {
            if(base64 == null)
            {
                return $"~/Images/Avatars/default.png";
            }


            byte[] bytes;

            try
            {
                bytes = Convert.FromBase64String(base64);
            }
            catch (Exception e)
            {
                return base64;
            }

            using (Image imageFile = Image.FromStream(new MemoryStream(bytes)))
            {
                string root = HttpContext.Current.Server.MapPath("~/Images/Avatars");

                Image thumbnail = (Image)(new Bitmap(imageFile, thumbSize));
                thumbnail.Save($"{root}/{filename}", ImageFormat.Png);

                return $"~/Images/Avatars/{filename}";
            }
        }
    }
}