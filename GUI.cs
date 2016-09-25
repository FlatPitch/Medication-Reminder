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
        private ListView mListView;
        DatabaseControl dbControl = new DatabaseControl();
        private List<ListViewVariables> medication;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //GUI creation stuff
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.GUI);

            //Database stuff
            var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var pathToDatabase = System.IO.Path.Combine(docsFolder, "db_sqlnet.db");
            dbControl.setPath(pathToDatabase);
            dbControl.deleteMedicationTable();
            dbControl.accessDatabase();
            dbControl.populateMedication();
            mListView = FindViewById<ListView>(Resource.Id.MedicationView);

            //Creating a list stuff
            medication = new List<ListViewVariables>();
            medication = dbControl.medication(dbControl.getLoggedIn());

            //adding a header too the top of the list
            ListViewVariables header = new ListViewVariables();
            header.Dosage = "Dosage";
            header.Time = "Time";
            header.Medication = "Medication";
            medication.Insert(0, header);
            

            //ListView implementation stuff
            MyListViewAdapter adapter = new MyListViewAdapter(this, medication);
            mListView.Adapter = adapter;
            



            //nextDayBtn = FindViewById<Button>(Resource.Id.nextDayBtn);
            //meds.ItemClick += Meds_ItemClick;
            //meds.ChoiceMode = Android.Widget.ChoiceMode.Single;


            /*nextDayBtn.Click += delegate
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                NextDay_DialogFragment dialog = new NextDay_DialogFragment();
                dialog.Show(transaction, "dialog fragment");
            };*/







        }

        private void Meds_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

    


    }
}

