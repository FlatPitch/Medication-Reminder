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
using Android.Graphics;



namespace MedicalApp
{
    class MyListViewAdapter : BaseAdapter<ListViewVariables>
    {
        private List<ListViewVariables> mItems;
        private Context mContext;
        public MyListViewAdapter(Context context, List<ListViewVariables> items)
        {
            mItems = items;
            mContext = context;
        }
        public override int Count
        {
            get
            {
                return mItems.Count;
            }

        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override ListViewVariables this[int position]
        {
            get
            {
                return mItems[position];
            }
        }

            public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if(row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.listview_row, null, false);
            }


            TextView Time = row.FindViewById<TextView>(Resource.Id.Time);
            Time.Text = mItems[position].Time;
            TextView Medication = row.FindViewById<TextView>(Resource.Id.Medication);
            Medication.Text = mItems[position].Medication;
            TextView Dosage = row.FindViewById<TextView>(Resource.Id.Dosage);
            Dosage.Text = mItems[position].Dosage;
            CheckBox checkBox = row.FindViewById<CheckBox>(Resource.Id.MedicationCheck);
            row.SetBackgroundColor(Color.DarkSeaGreen);

            //Testing time - Troy O'Shaughnessy (14865290)
            if (Time == null)
            {
                Console.WriteLine("Unit Test 1:  Time not set (failed)");
            }else
            {
                Console.WriteLine("Unit Test 1: Time is set:  Passed");
                
            }
            if (Medication == null)
            {
                Console.WriteLine("Unit test 2:  Medication not present (failed)");
            }else
            {
                Console.WriteLine("Unit Test 2: Medication is set: Passed");
            }
            if (Dosage == null)
            {
                Console.WriteLine("Unit test 3:  No dosage given (failed)");
            }else
            {
                Console.WriteLine("Unit Test 3: Dosage is set: Passed");
            }


            checkBox.Click += (o, e) => {
                if (checkBox.Checked && position != 0)
                { 
                    row.SetBackgroundColor(Color.DarkRed);
                }
                if (checkBox.Checked == false && position != 0)
                {
                    Medication.Text = mItems[position].Medication;
                    row.SetBackgroundColor(Color.DarkSeaGreen);
                }
                
               //liams special tests

                if(checkBox.Checked && row.DrawingCacheBackgroundColor == Color.DarkRed)
                {
                    Console.WriteLine("Unit Test 4: ");
                }
                if(checkBox.Checked == false && position == 0)
                {
                    Console.WriteLine("unit test 5: ");
                }
                if(checkBox.Checked && position == 0)
                {
                    Console.WriteLine("Unit test 6: ");
                }
                    
            };
            if(position == 0)
            {
                row.SetBackgroundColor(Color.Black);
                

            }
           
            
            return row;
        }


    }
    
}