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
using Android.Media;
using Java.Util;

namespace MedicalApp
{
    [Activity(Label = "GUI")]
    public class GUI : Activity
    {
        private Button nextDayBtn;
        private ListView mListView;
        DatabaseControl dbControl = new DatabaseControl();
        private List<ListViewVariables> medication;
        private AlarmManager alarmMngr;

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

            scheduleNotification();

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



        public void scheduleNotification()
        {
            System.Console.WriteLine("test 2");
            Calendar cal = Calendar.GetInstance(Java.Util.TimeZone.Default);
            AlarmManager alarmMngr = GetSystemService(AlarmService) as AlarmManager;
            alarmMngr = GetSystemService(AlarmService) as AlarmManager;


            int id = 0;
            for (int i = 1; i < medication.Count; ++i)
            {
                Intent alarmIntent = new Intent(this, typeof(NotificationPublisher));
                alarmIntent.PutExtra("MedicationName", medication[i].Medication);
                alarmIntent.PutExtra("Dosage", medication[i].Dosage);
                alarmIntent.PutExtra("Time", medication[i].Time);

                PendingIntent pendIntent = PendingIntent.GetBroadcast(this, id, alarmIntent,
                    PendingIntentFlags.UpdateCurrent);

                
               cal.Set(CalendarField.HourOfDay, convertTime(medication[i].Time, "Hour"));
               cal.Set(CalendarField.Minute, convertTime(medication[i].Time, "Minute"));

               alarmMngr.Set(AlarmType.RtcWakeup, cal.TimeInMillis, pendIntent);

                id++;
            }      
        }

        public int convertTime(string time, string key)
        {
            int newTime = 0;
            if (key.Equals("Hour"))
            {
                if (time.Contains("am"))
                {
                    newTime = Convert.ToInt32(time.Split(':')[0]);
                }
                else
                {
                    newTime = Convert.ToInt32(time.Split(':')[0]) + 12;
                }
            }
            else if (key.Equals("Minute"))
            {
                time = time.Split(':')[1];
                newTime = Convert.ToInt32(time.Substring(0,2));
            }

            return newTime;
        }

        private void Meds_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

    


    }
}

