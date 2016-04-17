using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace RaysHotDogs
{
    [Activity(Label = "Visit Ray's Store")]
    public class RayMapActivity : Activity
    {
        private Button _externalMap;
        private MapFragment _mapFragment;
        private GoogleMap _googleMap;
        private LatLng _rayLocation;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _rayLocation = new LatLng(50.846704, 4.352446);

            SetContentView(Resource.Layout.RayMapView);

            FindViews();
            HandleEvents();
            CreateMapFragment();
            UpdateMapView();
        }

        /// <summary>
        /// Finds the view objects and populates them into local view fields.
        /// </summary>
        private void FindViews()
        {
            _externalMap = FindViewById<Button>(Resource.Id.externalMapButton);
            FindViewById<FrameLayout>(Resource.Id.mapFrameLayout);
        }
        
        /// <summary>
        /// Sets up the Event Handlers for the button click events within the View.
        /// </summary>
        private void HandleEvents()
        {
            _externalMap.Click += ExternalMap_Click;
        }

        /// <summary>
        /// Handles the External Map button click event.
        /// </summary>
        /// <param name="sender">The object that triggered this event.</param>
        /// <param name="e">The EventArgs.</param>
        private void ExternalMap_Click(object sender, EventArgs e)
        {
            var rayLocationUri = Android.Net.Uri.Parse("geo:50.846704,4.352446");
            var mapIntent = new Intent(Intent.ActionView, rayLocationUri);
            StartActivity(mapIntent);
        }

        private void CreateMapFragment()
        {
            _mapFragment = FragmentManager.FindFragmentByTag("map") as MapFragment;

            if (_mapFragment != null) return;

            var googleMapOptions = new GoogleMapOptions()
                .InvokeMapType(GoogleMap.MapTypeSatellite)
                .InvokeZoomControlsEnabled(true)
                .InvokeCompassEnabled(true);

            var fragmentTransaction = FragmentManager.BeginTransaction();
            _mapFragment = MapFragment.NewInstance(googleMapOptions);
            fragmentTransaction.Add(Resource.Id.mapFrameLayout, _mapFragment, "map");
            fragmentTransaction.Commit();
        }

        private void UpdateMapView()
        {
            var mapReadyCallback = new LocalMapReady();

            mapReadyCallback.MapReady += (sender, args) =>
            {
                // Get the map.
                _googleMap = (sender as LocalMapReady)?.Map;
                if (_googleMap == null) return;

                // Add the marker.
                var markerOptions = new MarkerOptions();
                markerOptions.SetPosition(_rayLocation);
                markerOptions.SetTitle("Ray's Hot Dogs");
                _googleMap.AddMarker(markerOptions);

                // Zoom to location.
                var cameraUpdate = CameraUpdateFactory.NewLatLngZoom(_rayLocation, 15);
                _googleMap.MoveCamera(cameraUpdate);
            };

            // Set up the map.
            _mapFragment.GetMapAsync(mapReadyCallback);
        }

        private class LocalMapReady : Java.Lang.Object, IOnMapReadyCallback
        {
            public GoogleMap Map { get; private set; }

            public event EventHandler MapReady;

            public void OnMapReady(GoogleMap googleMap)
            {
                Map = googleMap;
                MapReady?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}