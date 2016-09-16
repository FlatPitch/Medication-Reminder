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

        public void setPath(string path)
        {
            this.pathToDB = path;
        }
        
        public string accessDatabase()
        {
            try
            {
                var db = new SQLiteConnection(this.pathToDB);
                db.CreateTable<Person>();
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

        public Boolean checkLogin(Person person)
        {
            Console.WriteLine("Checking login");
            var db = new SQLiteConnection(this.pathToDB);
            var Query_Login = db.Query<Person>("select * from Person WHERE Username LIKE ? AND Password LIKE ?", person.UserName, person.Password);
            
            if (Query_Login.Capacity > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void populateLogin()
        {
            var db = new SQLiteConnection(this.pathToDB);
            Person admin = new Person("admin", "admin");
            Person liam = new Person("Liam", "Maddren");
            Person troy = new Person("Troy", "O'Shaughnessy");
            Person brendan = new Person("Brendan", "Allan");
            Person jordan = new Person("Jordan", "Bailey");
            insertUpdateData(admin);
            insertUpdateData(liam);
            insertUpdateData(troy);
            insertUpdateData(brendan);
            insertUpdateData(jordan);
        }
    }


   
}