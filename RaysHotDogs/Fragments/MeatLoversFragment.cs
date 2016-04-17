using Android.OS;
using Android.Views;
using RaysHotDogs.Adapters;

namespace RaysHotDogs.Fragments
{
    public class MeatLoversFragment : BaseFragment
    {
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            FindViews();
            HandleEvents();

            HotDogs = DataService.GetHotDogsForGroup(1);
            ListView.Adapter = new HotDogListAdapter(Activity, HotDogs);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.MeatLoversFragment, container, false);
        }
    }
}