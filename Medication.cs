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
    class Medication
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public String Name { get; set; }
        public String medName { get; set; }
        public int Dosage { get; set; }
        public int Time { get; set; }
        public Medication()
        {
        
        }


        public Medication(String name, String medname, int dosage, int time)
        {
            this.Name = name;
            this.medName = medname;
            this.Dosage = dosage;
            this.Time = time;
        }

        public Medication(String medname, int dosage, int time)
        {
            this.medName = medname;
            this.Dosage = dosage;
            this.Time = time;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}",
              Time, medName, Dosage);
        }



    }
}