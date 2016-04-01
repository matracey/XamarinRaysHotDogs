using Android.Graphics;
using System.Net;

namespace RaysHotDogs.Utility
{
    public class ImageHelper
    {
        public static Bitmap GetImageBitmap(string url)
        {
            Bitmap imageBmp = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if(imageBytes != null && imageBytes.Length > 0)
                {
                    imageBmp = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBmp;
        }
    }
}