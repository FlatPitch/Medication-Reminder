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
using SQLite;

namespace MedicalApp
{
    class DatabaseControl
    {
        private string pathToDB { get; set; }
        private Person personTest;
        private static string USERNAME = "BLUE";
      
        

        public void setPath(string path)
        {
            this.pathToDB = path;
        }
        public string getLoggedIn()
        {
            return USERNAME;
        }
        // Used to instantiate the local DB's and create a connection to them
        public string accessDatabase()
        {
            try
            {
                var db = new SQLiteConnection(this.pathToDB);
                db.CreateTable<Person>();
                db.CreateTable<Medication>();
                return "Database created";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }

        public string insertUpdateData(Person data)
        {
            try
            {
                var db = new SQLiteConnection(this.pathToDB);
                if (db.Insert(data) != 0)
                    db.Update(data);
                return "Single data file inserted or updated";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }
        //Condense later with Person data
        public string insertUpdateData(Medication data)
        {
            try
            {
                var db = new SQLiteConnection(this.pathToDB);
                if (db.Insert(data) != 0)
                    db.Update(data);
                return "Single data file inserted or updated";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }

        public Boolean checkLogin(Person person)
        {
            var db = new SQLiteConnection(this.pathToDB);
            var Query_Login = db.Query<Person>("select * from Person WHERE Username LIKE ? AND Password LIKE ?", person.UserName, person.Password);
            
            if (Query_Login.Capacity > 0)
            {
                personTest = person;
                USERNAME = person.UserName;
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<string> medication(string username)
        {
            var meds = new List<string>();
             
            
            var db = new SQLiteConnection(this.pathToDB);
            var Query_Medication = db.Query<Medication>("SELECT DISTINCT * from Medication WHERE Name LIKE ?", username);
            int size = Query_Medication.Capacity;
            if(size == 0)
            {
                Medication m = new Medication("failed", "failed", 1, 1);
                meds.Add(m.ToString());
                return meds;
            }
            foreach(var names in Query_Medication)
            {
                Medication med = new Medication(names.medName, names.Dosage, names.Time);
                meds.Add(med.ToString());


            }
            return meds;
            
        }
        public void populateLogin()
        {
            var db = new SQLiteConnection(this.pathToDB);
            Person admin = new Person("admin", "admin"); 
            insertUpdateData(admin);
        }
        
        public void populateMedication()
        {
            var db = new SQLiteConnection(this.pathToDB);
            Medication test = new Medication("admin", "admin", 123, 321);
            Medication test1 = new Medication("admin", "ritilin", 20, 0400);
            insertUpdateData(test);
            insertUpdateData(test1);
        }
        public string medicationPartReturn(string section)
        {
            return null;
        }
        
       
    }



   
}