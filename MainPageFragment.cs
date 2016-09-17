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