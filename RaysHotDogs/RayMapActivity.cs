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

namespace RaysHotDogs
{
    [Activity(Label = "Visit Ray's Store")]
    public class RayMapActivity : Activity
    {
        private Button externalMap;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.RayMapView);

            FindViews();
            HandleEvents();
        }

        /// <summary>
        /// Finds the view objects and populates them into local view fields.
        /// </summary>
        private void FindViews()
        {
            externalMap = FindViewById<Button>(Resource.Id.mapButton);
        }
        
        /// <summary>
        /// Sets up the Event Handlers for the button click events within the View.
        /// </summary>
        private void HandleEvents()
        {
            externalMap.Click += ExternalMap_Click;
        }

        /// <summary>
        /// Handles the External Map button click event.
        /// </summary>
        /// <param name="sender">The object that triggered this event.</param>
        /// <param name="e">The EventArgs.</param>
        private void ExternalMap_Click(object sender, EventArgs e)
        {
            Android.Net.Uri rayLocationUri = Android.Net.Uri.Parse("geo:50.846704,4.352446");
            Intent mapIntent = new Intent(Intent.ActionView, rayLocationUri);
            StartActivity(mapIntent);
        }
    }
}