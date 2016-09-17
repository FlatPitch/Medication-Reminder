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
using Android.Support.V4.App;

namespace MedicalApp
{
    /*
     * This class represents the multiple MainPageFragment objects, in a sequence
     */
    class MedicationPagerAdapter : FragmentPagerAdapter
    {
        private const int NUM_OF_PAGES = 5;

        public MedicationPagerAdapter(Android.Support.V4.App.FragmentManager fm) : base(fm)
        {

        }

        public override int Count
        {
            get
            {
                return NUM_OF_PAGES;
            }
        }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            Console.WriteLine("Accessed!!!");
            return new MainPageFragment();
        }
    }
}