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
        
        public string StringExtender(int lengthToExtendTo, int lengthOfString)
        {
            string st1 = null;
            int lengthExtend = lengthToExtendTo - lengthOfString;
            for(int i = 0; i < lengthExtend; i++)
            {
                st1 += " ";
            }
            return st1;
        }

        public override string ToString()
        {
            string st1 = null;
            string stringTime = Convert.ToString(Time);
            string stringDosage = Convert.ToString(Dosage);
            if(stringTime.Length == 3)
            {
                stringTime = "0" + stringTime;
            }
            stringDosage += "mL";
            string meds = medName;
            meds += StringExtender(15, meds.Length);
            st1 += stringTime + " " + meds + " " + stringDosage;
            return st1;
        }



    }
}