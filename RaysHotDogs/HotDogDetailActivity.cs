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
using RaysHotDogs.Core.Model;
using RaysHotDogs.Core.Service;
using RaysHotDogs.Utility;

namespace RaysHotDogs
{
    [Activity(Label = "Hot Dog detail")]
    public class HotDogDetailActivity : Activity
    {
        private ImageView hotDogImageView;
        private TextView hotDogNameTextView;
        private TextView shortDescriptionTextView;
        private TextView descriptionTextView;
        private TextView priceTextView;
        private EditText amountEditText;
        private Button cancelButton;
        private Button orderButton;

        private HotDog selectedHotDog;
        private HotDogDataService dataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.HotDogDetailView);

            HotDogDataService dataService = new HotDogDataService();
            var selectedDogId = Intent.Extras.GetInt("selectedHotDogId");
            selectedHotDog = dataService.GetHotDog(selectedDogId);

            FindViews();
            BindData();
            HandleEvents();
        }

        /// <summary>
        /// Finds the views within the HotDogDetailView and populates them into the local fields.
        /// </summary>
        private void FindViews()
        {
            hotDogImageView = FindViewById<ImageView>(Resource.Id.hotDogImageView);
            hotDogNameTextView = FindViewById<TextView>(Resource.Id.hotDogNameTextView);
            shortDescriptionTextView = FindViewById<TextView>(Resource.Id.shortDescriptionTextView);
            descriptionTextView = FindViewById<TextView>(Resource.Id.descriptionTextView);
            priceTextView = FindViewById<TextView>(Resource.Id.priceTextView);
            amountEditText = FindViewById<EditText>(Resource.Id.amountEditText);
            cancelButton = FindViewById<Button>(Resource.Id.cancelButton);
            orderButton = FindViewById<Button>(Resource.Id.orderButton);
        }

        /// <summary>
        /// Binds the Data Model from the Data Service to the View elements.
        /// </summary>
        private void BindData()
        {
            hotDogNameTextView.Text = selectedHotDog.Name;
            shortDescriptionTextView.Text = selectedHotDog.ShortDescription;
            descriptionTextView.Text = selectedHotDog.Description;
            priceTextView.Text = @"Price: $"+selectedHotDog.Price;
            hotDogImageView.SetImageBitmap(ImageHelper.GetImageBitmap("http://gillcleerenpluralsight.blob.core.windows.net/files/" + selectedHotDog.ImagePath + ".jpg"));
        }

        /// <summary>
        /// Sets up the event handlers for Button elements.
        /// </summary>
        private void HandleEvents()
        {
            orderButton.Click += OrderButton_Click;
            cancelButton.Click += CancelButton_Click;
        }

        /// <summary>
        /// Handles the Order button click event.
        /// </summary>
        /// <param name="sender">The object that triggered this event.</param>
        /// <param name="e">The EventArgs.</param>
        private void OrderButton_Click(object sender, EventArgs e)
        {
            var amount = int.Parse(amountEditText.Text);

            var intent = new Intent();
            intent.PutExtra("selectedHotDogId", selectedHotDog.Id);
            intent.PutExtra("amount", amount);

            SetResult(Result.Ok, intent);

            Finish();
        }

        /// <summary>
        /// Handles the Cancel button click event.
        /// </summary>
        /// <param name="sender">The object that triggered this event.</param>
        /// <param name="e">The EventArgs.</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            // TODO
        }
    }
}