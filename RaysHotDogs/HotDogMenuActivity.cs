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
using RaysHotDogs.Adapters;

namespace RaysHotDogs
{
    [Activity(Label = "Hot Dog Menu")]
    public class HotDogMenuActivity : Activity
    {
        private ListView hotDogListView;
        private List<HotDog> allHotDogs;
        private HotDogDataService dataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.HotDogMenuView);

            hotDogListView = FindViewById<ListView>(Resource.Id.hotDogListView);
            dataService = new HotDogDataService();
            allHotDogs = dataService.GetAllHotDogs();

            hotDogListView.Adapter = new HotDogListAdapter(this, allHotDogs);
            hotDogListView.FastScrollEnabled = true;

            hotDogListView.ItemClick += HotDogListView_ItemClick;
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if(resultCode == Result.Ok && requestCode == 100)
            {
                var selectedDog = dataService.GetHotDog(data.GetIntExtra("selectedHotDogId", 0));

                var dialog = new AlertDialog.Builder(this);
                dialog.SetTitle("Confirmation");
                dialog.SetMessage(string.Format("You've add {0} {1} to your basket.", data.GetIntExtra("amount", 0), selectedDog.Name));
                dialog.Show();
            }
        }

        /// <summary>
        /// Handles the Item click event.
        /// </summary>
        /// <param name="sender">The object that triggered this event.</param>
        /// <param name="e">The EventArgs.</param>
        private void HotDogListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var dog = allHotDogs[e.Position];

            var intent = new Intent();
            intent.SetClass(this, typeof(HotDogDetailActivity));
            intent.PutExtra("selectedHotDogId", dog.Id);

            StartActivityForResult(intent, 100);
        }
    }
}