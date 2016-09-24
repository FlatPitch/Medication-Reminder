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
using System.Collections;
using SQLite;

namespace MedicalApp
{
    [Activity(Label = "GUI")]
    public class GUI : Activity
    {
        private Button nextDayBtn;
        private ListView meds;
        DatabaseControl dbControl = new DatabaseControl();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.GUI);
            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var pathToDatabase = System.IO.Path.Combine(docsFolder, "db_sqlnet.db");
            dbControl.setPath(pathToDatabase);
            dbControl.accessDatabase();
            dbControl.populateMedication();
          


            meds = FindViewById<ListView>(Resource.Id.MedicationView);

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItemChecked, dbControl.medication(dbControl.getLoggedIn()));
            meds.Adapter = null;
            meds.Adapter = adapter;
            

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