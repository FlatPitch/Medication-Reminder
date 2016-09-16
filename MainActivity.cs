using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace Attempt_7
{
    [Activity(Label = "Attempt_7", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private List <Medical> myItems;
        private ListView myListView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            myListView = FindViewById<ListView>(Resource.Id.MyListView1);
      
            myItems = new List<Medical>();
            myItems.Add(new Medical() {time = "10:00PM", medication = "Paracetamol", quantity = "2", checkbox = "Ticked" });
            myItems.Add(new Medical() { time = "11:30PM", medication = "Ibuprofen", quantity = "2", checkbox = "Unticked" });
            myItems.Add(new Medical() { time = "1:00PM", medication = "Strepsil", quantity = "2", checkbox = "Unticked" });

            MyListViewAdapter adapter = new MyListViewAdapter(this, myItems);

            myListView.Adapter = adapter;
        }
    }
}

