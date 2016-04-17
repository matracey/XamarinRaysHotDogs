using Android.OS;
using Android.Views;
using RaysHotDogs.Adapters;

namespace RaysHotDogs.Fragments
{
    public class FavoriteHotDogFragment : BaseFragment
    {
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            FindViews();
            HandleEvents();

            HotDogs = DataService.GetFavoriteHotDogs();
            ListView.Adapter = new HotDogListAdapter(Activity, HotDogs);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.FavoriteHotDogFragment, container, false);
        }
    }
}