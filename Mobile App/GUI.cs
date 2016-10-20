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
    [Activity(Label = "GUI v1.0")]
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
            nextDayBtn = FindViewById<Button>(Resource.Id.NextDayBtn);
            nextDayBtn.Click += delegate
            {
                displayNextDayMedication();
            };

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

            displayTodayMedication();
            

        }

        /* displayTodayMedication()
         * This method iterates through the medication list and collects all Medication objects
         * that have the current date.
         * It then passes that collection to the ListViewAdapter
         */
        private void displayTodayMedication()
        {
            List<ListViewVariables> todayMedication = new List<ListViewVariables>();
            todayMedication.Add(medication[0]); //adding the header
            for (int i = 1; i < medication.Count; ++i)
            {
                if (medication[i].Date == getSystemDate())
                {
                    todayMedication.Add(medication[i]);
                }
            }

            MyListViewAdapter adapter = new MyListViewAdapter(this, todayMedication);
            mListView.Adapter = adapter;

            nextDayBtn.Text = "View Tomorrow Medication";
            nextDayBtn.Click += delegate
            {
                displayNextDayMedication();
            };
        }

        /* displayNextDayMedication()
         * This method iterates through the medication list and collects all Medication objects
         * that have tomorrow's date.
         * It then passes that collection to the ListViewAdapter
         */
        private void displayNextDayMedication()
        {
            List<ListViewVariables> nextDayMeds = new List<ListViewVariables>();
            nextDayMeds.Add(medication[0]);
            for (int i = 1; i < medication.Count; ++i)
            {
                if (medication[i].Date == getTomorrowSystemDate())
                {
                    nextDayMeds.Add(medication[i]);
                }
            }
            MyListViewAdapter adapter = new MyListViewAdapter(this, nextDayMeds);
            mListView.Adapter = adapter;

            nextDayBtn.Text = "View Today Medication";
            nextDayBtn.Click += delegate
            {
                displayTodayMedication();
            };
        }

        /* public string getSystemDate()
         * This method gets the current date on the Android system and formats it
         * to dd/mm/yyyy
         * return: string - system date formatted in dd/mm/yyyy
         */
        public string getSystemDate()
        {
            Calendar cal = Calendar.GetInstance(Java.Util.TimeZone.Default);

            string sysDate = cal.Get(CalendarField.DayOfMonth).ToString() + "\\" +
                            (cal.Get(CalendarField.Month) + 1).ToString() + "\\" + cal.Get(CalendarField.Year).ToString();

            return (sysDate);
        }

        /* public string getTomorrowSystemDate()
         * This method gets the tomorrow date on the Android system and formats it
         * to dd/mm/yyyy
         * return: string - system date formatted in dd/mm/yyyy
         */
        public string getTomorrowSystemDate()
        {
            GregorianCalendar greCal = new GregorianCalendar();
            greCal.Add(CalendarField.Date, 1);
            string tomorrowSysDate = greCal.Get(CalendarField.DayOfMonth).ToString() + "\\" +
                            (greCal.Get(CalendarField.Month) + 1).ToString() + "\\" + 
                            greCal.Get(CalendarField.Year).ToString();

            return (tomorrowSysDate);
        }

        /* scheduleNotification() 
         * This method uses the data inside the medication list to
         * schedule an alarm in the Android system when it needs to be taken.
         * It creates an Intent for each alarm that creates the class which displays
         * the notification
	    */
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

                Console.WriteLine($"Date: {medication[i].Date}");

                PendingIntent pendIntent = PendingIntent.GetBroadcast(this, id, alarmIntent,
                    PendingIntentFlags.UpdateCurrent);

               cal.Set(CalendarField.DayOfMonth, Convert.ToInt32(splitDate(medication[i].Date, "Day")));
               cal.Set(CalendarField.Month, Convert.ToInt32(splitDate(medication[i].Date, "Month")));
               cal.Set(CalendarField.Year, Convert.ToInt32(splitDate(medication[i].Date, "Year")));
               cal.Set(CalendarField.HourOfDay, convertTime(medication[i].Time, "Hour"));
               cal.Set(CalendarField.Minute, convertTime(medication[i].Time, "Minute"));

               alarmMngr.Set(AlarmType.RtcWakeup, cal.TimeInMillis, pendIntent);

                id++;
            }      
        }

        /* string splitDate(string date, string key)
         * This method takes in a string date in the form dd/mm/yyyy
         * and returns the Day or Month or Year part depending on the key
         * param: string date - date to be split
         * param: string key - string saying if to return the day, month or year
         * return: string - part of date requested
         */
        public string splitDate(string date, string key)
        {
            if (key.Equals("Day"))
            {
                return (date.Substring(0, 2));
            }
            else if (key.Equals("Month"))
            {
                return (date.Substring(3, 2));
            }
            if (key.Equals("Year"))
            {
                return (date.Substring(6, 4));
            }
            return ("");
        }

        /* int convertTime(string time, string key) 
         * This method takes in a 12-hour time string (e.g. 10:53pm) 
         * and returns the hour or minute in 24-hours format depending on the key.
         * param: string time - time that is to be converted
         * param: string key - string saying if to return hour or minute
         * return: int - the converted time as an integer
	    */
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
                time = time.TrimEnd(new Char[] { 'a', 'p', 'm' });
                newTime = Convert.ToInt32(time);
            }

            return newTime;
        }

        private void Meds_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

    


    }
}

