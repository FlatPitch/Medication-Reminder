using System;
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

            mButton.Click += mButton_Click;
            mRelativeLayout.Click += mRelativeLayout_Click;
         }

        void mButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(GUI));
            this.StartActivity(intent);
            this.Finish();
        }

        void mRelativeLayout_Click(object sender, EventArgs e)
        {
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Activity.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.None);
        }

    }
}


