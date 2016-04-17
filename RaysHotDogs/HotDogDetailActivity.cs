using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using RaysHotDogs.Core.Model;
using RaysHotDogs.Core.Service;
using RaysHotDogs.Utility;

namespace RaysHotDogs
{
    [Activity(Label = "Hot Dog detail")]
    public class HotDogDetailActivity : Activity
    {
        private ImageView _hotDogImageView;
        private TextView _hotDogNameTextView;
        private TextView _shortDescriptionTextView;
        private TextView _descriptionTextView;
        private TextView _priceTextView;
        private EditText _amountEditText;
        private Button _cancelButton;
        private Button _orderButton;

        private HotDog _selectedHotDog;
        private readonly HotDogDataService _dataService;

        public HotDogDetailActivity()
        {
            _dataService = new HotDogDataService();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.HotDogDetailView);

            var selectedDogId = Intent.Extras.GetInt("selectedHotDogId");
            _selectedHotDog = _dataService.GetHotDog(selectedDogId);

            FindViews();
            BindData();
            HandleEvents();
        }

        /// <summary>
        /// Finds the views within the HotDogDetailView and populates them into the local fields.
        /// </summary>
        private void FindViews()
        {
            _hotDogImageView = FindViewById<ImageView>(Resource.Id.hotDogImageView);
            _hotDogNameTextView = FindViewById<TextView>(Resource.Id.hotDogNameTextView);
            _shortDescriptionTextView = FindViewById<TextView>(Resource.Id.shortDescriptionTextView);
            _descriptionTextView = FindViewById<TextView>(Resource.Id.descriptionTextView);
            _priceTextView = FindViewById<TextView>(Resource.Id.priceTextView);
            _amountEditText = FindViewById<EditText>(Resource.Id.amountEditText);
            _cancelButton = FindViewById<Button>(Resource.Id.cancelButton);
            _orderButton = FindViewById<Button>(Resource.Id.orderButton);
        }

        /// <summary>
        /// Binds the Data Model from the Data Service to the View elements.
        /// </summary>
        private void BindData()
        {
            _hotDogNameTextView.Text = _selectedHotDog.Name;
            _shortDescriptionTextView.Text = _selectedHotDog.ShortDescription;
            _descriptionTextView.Text = _selectedHotDog.Description;
            _priceTextView.Text = @"Price: $"+_selectedHotDog.Price;
            _hotDogImageView.SetImageBitmap(ImageHelper.GetImageBitmap($"http://gillcleerenpluralsight.blob.core.windows.net/files/{_selectedHotDog.ImagePath}.jpg"));
        }

        /// <summary>
        /// Sets up the event handlers for Button elements.
        /// </summary>
        private void HandleEvents()
        {
            _orderButton.Click += OrderButton_Click;
            _cancelButton.Click += CancelButton_Click;
        }

        /// <summary>
        /// Handles the Order button click event.
        /// </summary>
        /// <param name="sender">The object that triggered this event.</param>
        /// <param name="e">The EventArgs.</param>
        private void OrderButton_Click(object sender, EventArgs e)
        {
            var amount = int.Parse(_amountEditText.Text);

            var intent = new Intent();
            intent.PutExtra("selectedHotDogId", _selectedHotDog.Id);
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