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
using Android.Support.V4.App;
using Android.Support.V4.View; /*Resolve error by adding Android Support Libray v4 component:
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
    public class MainScreenActivity : FragmentActivity
    {
        private ViewPager mPager; //handles swiping and animation when moving across screens

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainPageActivity_ScreenSlide);

            // Instantiating the ViewPager and PagerAdapter
            mPager = FindViewById<ViewPager>(Resource.Id.pager);
            mPager.Adapter = new MedicationPagerAdapter(SupportFragmentManager);
        }
    }

    /* 
     * This class returns the screen to be displayed as the user swipes across
     * MainScreenActivity
     */
   public class MainPageFragment : Android.Support.V4.App.Fragment
    {
        public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            Console.WriteLine("Inflating Screen");
            var rootView = inflater.Inflate(Resource.Layout.MainScreen, container, false);

            return rootView;
        }
    }
}