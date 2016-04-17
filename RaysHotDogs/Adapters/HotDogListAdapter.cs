using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using RaysHotDogs.Core.Model;
using RaysHotDogs.Utility;

namespace RaysHotDogs.Adapters
{
    public class HotDogListAdapter : BaseAdapter<HotDog>
    {
        private readonly List<HotDog> _items;
        private readonly Activity _context;

        public HotDogListAdapter(Activity context, List<HotDog> items) : base()
        {
            _context = context;
            _items = items;
        }

        public override int Count => _items?.Count ?? 0;

        public override HotDog this[int position] => _items[position];

        public override bool IsEmpty => _items.Count == 0;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _items[position];

            var imageBitmap = ImageHelper.GetImageBitmap($"http://gillcleerenpluralsight.blob.core.windows.net/files/{item.ImagePath}.jpg");

            if(convertView == null)
                convertView = _context.LayoutInflater.Inflate(Resource.Layout.HotDogRowView, null);

            convertView.FindViewById<ImageView>(Resource.Id.hotDogImageView).SetImageBitmap(imageBitmap);
            convertView.FindViewById<TextView>(Resource.Id.hotDogNameTextView).Text = item.Name;
            convertView.FindViewById<TextView>(Resource.Id.shortDescriptionTextView).Text = item.ShortDescription;
            convertView.FindViewById<TextView>(Resource.Id.priceTextView).Text = "$"+ item.Price;

            return convertView;
        }
    }
}