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

        public void deleteMedicationTable()
        {
            var db = new SQLiteConnection(this.pathToDB);
            db.DeleteAll<Medication>();
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


        public List<ListViewVariables> medication(string username)
        {
            var meds = new List<ListViewVariables>();
             
            
            var db = new SQLiteConnection(this.pathToDB);
            var Query_Medication = db.Query<Medication>("SELECT DISTINCT * from Medication WHERE Name LIKE ?", username);
            int size = Query_Medication.Capacity;
            
            foreach(var names in Query_Medication)
            {
                ListViewVariables medication = new ListViewVariables();
                medication.Medication = names.medName;
                medication.Time = names.convertTime();
                medication.Dosage = Convert.ToString(names.Dosage) + "g";
                

                meds.Add(medication);


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
            Medication sertraline = new Medication("admin", "Sertraline", 30, 0900);
            Medication ritilin = new Medication("admin", "Ritilin", 20, 0900);
            Medication citalopram = new Medication("admin", "Citalopram", 20, 0900);
            Medication ritilin2 = new Medication("admin", "Ritilin", 20, 1300);
            insertUpdateData(sertraline);
            insertUpdateData(ritilin);
            insertUpdateData(citalopram);
            insertUpdateData(ritilin2);

        }
       
        
       
    }



   
}