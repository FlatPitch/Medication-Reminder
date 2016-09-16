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

namespace Attempt_7
{
    class MyListViewAdapter : BaseAdapter<Medical>
    {
        private List<Medical> myItems;
        private Context myContext;

        public MyListViewAdapter(Context context, List<Medical> items){
            myItems = items;
            myContext = context;
        }
        public override int Count
        {
            get
            {
                return myItems.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Medical this[int position]{
            get
            {
                return myItems[position];
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if(row == null)
            {
                row = LayoutInflater.From(myContext).Inflate(Resource.Layout.listview_row, null, false);
            }

            TextView textViewTime = row.FindViewById<TextView>(Resource.Id.textViewTime);
            textViewTime.Text = myItems[position].time;

            TextView textViewMed = row.FindViewById<TextView>(Resource.Id.textViewMed);
            textViewMed.Text = myItems[position].medication;

            TextView textViewQuantity = row.FindViewById<TextView>(Resource.Id.textViewQuantity);
            textViewQuantity.Text = myItems[position].quantity;

            TextView textViewChkbox = row.FindViewById<TextView>(Resource.Id.textViewChkbox);
            textViewChkbox.Text = myItems[position].checkbox;

            return row;
        }
    }
}