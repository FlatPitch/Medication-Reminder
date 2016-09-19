using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.App;
/*using Android.Support.V4.View; /*Resolve error by adding Android Support Libray v4 component:
                               *Right click Components in Solution Explorer and 'add Compoent'
                               *Search 'Android Support Libray v4' and add it*/

namespace MedicalApp
{
    /*
     * Parent class for the Main Screen
     * Manages the ViewPager and Fragments for swiping accross the screen
     * to show current and future days medication
     */
    [Activity(Label = "Main Screen")]
    public class MainScreenActivity : Activity
    {
        private Button nextDayBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainScreen);

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