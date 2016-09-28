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

        public string convertTime()
        {
            Time = this.Time;
            string AmOrPm = null;
            string newTime = null;
            int FirstTwoDigits = Time / 100;
            int lastTwoDidgits = Time % 100;
            int lastDigit = Time % 10;
            if(FirstTwoDigits > 12)
            {
                AmOrPm = "pm";
                FirstTwoDigits = FirstTwoDigits - 12;
            }
            else { AmOrPm = "am"; }
   
            newTime += Convert.ToString(FirstTwoDigits);
            newTime += ":";
            newTime += Convert.ToString(lastTwoDidgits);
            if (lastDigit == 0)
            {
                newTime += "0";
            }
            newTime += AmOrPm;
            return newTime;
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