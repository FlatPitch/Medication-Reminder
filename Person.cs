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
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        

        public override string ToString()
        {
            return string.Format(" UserName={0}, Password={1}]", UserName, Password);

        }
        public Person(string user, string password)
        {
            this.UserName = user;
            this.Password = password;
            
        }
        public Person()
        {

        }
    }
}
  
