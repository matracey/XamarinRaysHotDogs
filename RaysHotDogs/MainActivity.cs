using Android.App;
using Android.Widget;
using Android.OS;

namespace RaysHotDogs
{
    [Activity(Label = "Ray's Hot Dogs")]
    public class MainActivity : Activity
    {
        private int _count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            var button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate { button.Text = $"{_count++} clicks!"; };
        }
    }
}

