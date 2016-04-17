using Android.Graphics;
using System.Net;
using static Android.Graphics.BitmapFactory;

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
                    imageBmp = DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBmp;
        }

        public static Bitmap GetImageBitmap(string fileName, int width, int height)
        {
            var options = new Options { InJustDecodeBounds = true };
            DecodeFile(fileName, options);

            var outHeight = options.OutHeight;
            var outWidth = options.OutWidth;
            var inSampleSize = 1;
            
            if(outHeight > height || outWidth > width)
                inSampleSize = outWidth > outHeight ? outHeight / height : outWidth / width;

            options.InSampleSize = inSampleSize;
            options.InJustDecodeBounds = false;
            var resizedBitmap = DecodeFile(fileName, options);

            return resizedBitmap;
        }
    }
}