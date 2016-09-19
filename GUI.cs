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

namespace MedicalApp
{
    [Activity(Label = "GUI")]
    public class GUI : Activity
    {
        private Button nextDayBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GUI);

            nextDayBtn = FindViewById<Button>(Resource.Id.nextDayBtn);

            nextDayBtn.Click += delegate
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                NextDay_DialogFragment dialog = new NextDay_DialogFragment();
                dialog.Show(transaction, "dialog fragment");
            };

        }
    }
}