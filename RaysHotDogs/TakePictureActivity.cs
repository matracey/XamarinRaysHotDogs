using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
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
        private ImageView _rayPicture;
        private Button _takePicture;
        private File _imageDirectory;
        private File _imageFile;
        private Bitmap _imageBitmap;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.TakePictureView);
            FindViews();
            HandleEvents();

            _imageDirectory = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), "RaysHotDogs");
            if (!_imageDirectory.Exists()) _imageDirectory.Mkdirs();
        }

        private void FindViews()
        {
            _rayPicture = FindViewById<ImageView>(Resource.Id.rayPictureImageView);
            _takePicture = FindViewById<Button>(Resource.Id.takePictureButton);
        }

        private void HandleEvents()
        {
            _takePicture.Click += TakePicture_Click;
        }

        private void TakePicture_Click(object sender, EventArgs e)
        {
            var intent = new Intent(MediaStore.ActionImageCapture);
            _imageFile = new File(_imageDirectory, $"PhotoWithRay_{Guid.NewGuid()}.jpg");
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(_imageFile));
            StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            var height = _rayPicture.Height;
            var width = _rayPicture.Width;
            _imageBitmap = ImageHelper.GetImageBitmap(_imageFile.Path, width, height);

            if(_imageBitmap != null)
            {
                _rayPicture.SetImageBitmap(_imageBitmap);
                _imageBitmap = null;
            }

            GC.Collect();
        }
    }
}