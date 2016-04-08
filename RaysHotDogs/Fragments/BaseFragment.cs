using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using RaysHotDogs.Core.Service;
using RaysHotDogs.Core.Model;

namespace RaysHotDogs.Fragments
{
    public class BaseFragment : Fragment
    {
        protected ListView listView;
        protected HotDogDataService dataService;
        protected List<HotDog> hotDogs;

        public BaseFragment()
        {
            dataService = new HotDogDataService();
        }

        protected void FindViews()
        {
            listView = View.FindViewById<ListView>(Resource.Id.hotDogListView);
        }

        protected void HandleEvents()
        {
            listView.ItemClick += ListView_ItemClick;
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var dog = hotDogs[e.Position];

            var intent = new Intent();
            intent.SetClass(this.Activity, typeof(HotDogDetailActivity));
            intent.PutExtra("selectedHotDogId", dog.Id);

            StartActivityForResult(intent, 100);
        }
    }
}