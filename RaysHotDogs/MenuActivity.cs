using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace RaysHotDogs
{
    [Activity(Label = "Ray's Hot Dogs", MainLauncher = true, Icon = "@drawable/smallIcon")]
    public class MenuActivity : Activity
    {
        private Button _order;
        private Button _about;
        private Button _map;
        private Button _picture;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainMenu);

            FindViews();

            HandleEvents();
        }

        /// <summary>
        /// Finds the view objects and populates them into local view fields.
        /// </summary>
        private void FindViews()
        {
            _order = FindViewById<Button>(Resource.Id.orderButton);
            FindViewById<Button>(Resource.Id.cartButton);
            _about = FindViewById<Button>(Resource.Id.aboutButton);
            _map = FindViewById<Button>(Resource.Id.mapButton);
            _picture = FindViewById<Button>(Resource.Id.takePictureButton);
        }

        /// <summary>
        /// Sets up the Event Handlers for the button click events within the View.
        /// </summary>
        private void HandleEvents()
        {
            _order.Click += Order_Click;
            _about.Click += About_Click;
            _picture.Click += Picture_Click;
            _map.Click += Map_Click;
        }

        /// <summary>
        /// Handles the Order button click event.
        /// </summary>
        /// <param name="sender">The object that triggered this event.</param>
        /// <param name="e">The EventArgs.</param>
        private void Order_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(HotDogMenuActivity));
            StartActivity(intent);
        }

        /// <summary>
        /// Handles the About button click event.
        /// </summary>
        /// <param name="sender">The object that triggered this event.</param>
        /// <param name="e">The EventArgs.</param>
        private void About_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AboutActivity));
            StartActivity(intent);
        }

        /// <summary>
        /// Handles the Take Picture button click event.
        /// </summary>
        /// <param name="sender">The object that triggered this event.</param>
        /// <param name="e">The EventArgs.</param>
        private void Picture_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(TakePictureActivity));
            StartActivity(intent);
        }

        /// <summary>
        /// Handles the Map button click event.
        /// </summary>
        /// <param name="sender">The object that triggered this event.</param>
        /// <param name="e">The EventArgs.</param>
        private void Map_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(RayMapActivity));
            StartActivity(intent);
        }
    }
}