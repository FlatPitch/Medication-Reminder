<<<<<<< HEAD
﻿using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Views.InputMethods;

namespace MedicalApp
{
    [Activity(Label = "MedicalApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        RelativeLayout mRelativeLayout;
        Button mButton;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mRelativeLayout = FindViewById<RelativeLayout>(Resource.Id.mainView);
            mButton = FindViewById<Button>(Resource.Id.btnLogin);

            mButton.Click += delegate
            {
                Intent intent = new Intent(this, typeof(GUI));
                this.StartActivity(intent);
                this.Finish();
            };

            mRelativeLayout.Click += delegate
            {
                InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Activity.InputMethodService);
                inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.None);

            };
         }
    }
}


=======
﻿using System;
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

>>>>>>> 6fcacabe6bc639e5f0cb98f60593b69c5ea42a78
