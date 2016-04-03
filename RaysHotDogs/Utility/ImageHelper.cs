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

        public static Bitmap GetImageBitmap(string fileName, int width, int height)
        {
            BitmapFactory.Options options = new BitmapFactory.Options { InJustDecodeBounds = true };
            BitmapFactory.DecodeFile(fileName, options);

            int outHeight = options.OutHeight;
            int outWidth = options.OutWidth;
            int inSampleSize = 1;
            
            if(outHeight > height || outWidth > width)
                inSampleSize = outWidth > outHeight ? outHeight / height : outWidth / width;

            options.InSampleSize = inSampleSize;
            options.InJustDecodeBounds = false;
            Bitmap resizedBitmap = BitmapFactory.DecodeFile(fileName, options);

            return resizedBitmap;
        }
    }
}