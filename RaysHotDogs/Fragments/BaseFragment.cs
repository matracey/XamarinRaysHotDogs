using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Widget;
using RaysHotDogs.Core.Service;
using RaysHotDogs.Core.Model;

namespace RaysHotDogs.Fragments
{
    public class BaseFragment : Fragment
    {
        protected ListView ListView;
        protected HotDogDataService DataService;
        protected List<HotDog> HotDogs;

        public BaseFragment()
        {
            DataService = new HotDogDataService();
        }

        protected void FindViews()
        {
            ListView = View.FindViewById<ListView>(Resource.Id.hotDogListView);
        }

        protected void HandleEvents()
        {
            ListView.ItemClick += ListView_ItemClick;
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var dog = HotDogs[e.Position];

            var intent = new Intent();
            intent.SetClass(this.Activity, typeof(HotDogDetailActivity));
            intent.PutExtra("selectedHotDogId", dog.Id);

            StartActivityForResult(intent, 100);
        }
    }
}