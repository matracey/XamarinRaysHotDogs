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
    [Activity(Label = "About Ray's Hot Dogs")]
    public class AboutActivity : Activity
    {
        private TextView _phoneNumber;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AboutView);

            FindViews();

            HandleEvents();
        }

        /// <summary>
        /// Finds the view objects and populates them into local view fields.
        /// </summary>
        private void FindViews()
        {
            _phoneNumber = FindViewById<TextView>(Resource.Id.phoneNumberTextView);
        }

        /// <summary>
        /// Sets up the Event Handlers for the button click events within the View.
        /// </summary>
        private void HandleEvents()
        {
            _phoneNumber.Click += PhoneNumber_Click;
        }

        /// <summary>
        /// Handles the Phone number click event.
        /// </summary>
        /// <param name="sender">The object that triggered this event.</param>
        /// <param name="e">The EventArgs.</param>
        private void PhoneNumber_Click(object sender, EventArgs e)
        {
            var intent = new Intent(Intent.ActionCall);
            intent.SetData(Android.Net.Uri.Parse("tel:" + _phoneNumber.Text));
            StartActivity(intent);
        }
    }
}