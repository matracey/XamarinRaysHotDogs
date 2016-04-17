using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using RaysHotDogs.Core.Service;
using RaysHotDogs.Fragments;

namespace RaysHotDogs
{
    [Activity(Label = "Hot Dog Menu")]
    public class HotDogMenuActivity : Activity
    {
        private readonly HotDogDataService _dataService;

        public HotDogMenuActivity()
        {
            _dataService = new HotDogDataService();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.HotDogMenuView);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            AddTab("Favorites", Resource.Drawable.FavoritesIcon, new FavoriteHotDogFragment());
            AddTab("Meat Lovers", Resource.Drawable.MeatLoversIcon, new MeatLoversFragment());
            AddTab("Veggie Lovers", Resource.Drawable.VeggieLoversIcon, new VeggieLoversFragment());
        }

        private void AddTab(string tabText, int iconResourceId, Fragment view)
        {
            var tab = ActionBar.NewTab();
            tab.SetText(tabText);
            tab.SetIcon(iconResourceId);

            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                // Check for existing Fragment in the container.
                var fragment = FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
                // Remove the existing Fragment if it exists.
                if (fragment != null) e.FragmentTransaction.Remove(fragment);
                // Add the Fragment that should be added.
                e.FragmentTransaction.Add(Resource.Id.fragmentContainer, view);
            };

            tab.TabUnselected += (sender, e) => e.FragmentTransaction.Remove(view);

            ActionBar.AddTab(tab);
        }

        /// <summary>
        /// Called when an activity exits, giving you the requestCode you started it with, the resultCode it returned, and any additional data from it.
        /// </summary>
        /// <param name="requestCode">The integer request code originally supplied to startActivityForResult(), allowing you to identify who this result came from.</param>
        /// <param name="resultCode">The integer result code returned by the child activity through its setResult().</param>
        /// <param name="data">An Intent, which can return result data to the caller (various data can be attached to Intent "extras").</param>
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode != Result.Ok || requestCode != 100) return;

            var selectedDog = _dataService.GetHotDog(data.GetIntExtra("selectedHotDogId", 0));

            var dialog = new AlertDialog.Builder(this);
            dialog.SetTitle("Confirmation");
            dialog.SetMessage($"You've added {data.GetIntExtra("amount", 0)} {selectedDog.Name} to your basket.");
            dialog.Show();
        }
    }
}