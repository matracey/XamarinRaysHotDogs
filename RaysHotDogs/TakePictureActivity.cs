using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using Android.Provider;
using Android.Graphics;
using RaysHotDogs.Utility;

namespace RaysHotDogs
{
    [Activity(Label = "Take a picture with Ray")]
    public class TakePictureActivity : Activity
    {
        private ImageView rayPicture;
        private Button takePicture;
        private File imageDirectory;
        private File imageFile;
        private Bitmap imageBitmap;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.TakePictureView);
            FindViews();
            HandleEvents();

            imageDirectory = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), "RaysHotDogs");
            if (!imageDirectory.Exists()) imageDirectory.Mkdirs();
        }

        private void FindViews()
        {
            rayPicture = FindViewById<ImageView>(Resource.Id.rayPictureImageView);
            takePicture = FindViewById<Button>(Resource.Id.takePictureButton);
        }

        private void HandleEvents()
        {
            takePicture.Click += TakePicture_Click;
        }

        private void TakePicture_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            imageFile = new File(imageDirectory, string.Format("PhotoWithRay_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(imageFile));
            StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            int height = rayPicture.Height;
            int width = rayPicture.Width;
            imageBitmap = ImageHelper.GetImageBitmap(imageFile.Path, width, height);

            if(imageBitmap != null)
            {
                rayPicture.SetImageBitmap(imageBitmap);
                imageBitmap = null;
            }

            GC.Collect();
        }
    }
}