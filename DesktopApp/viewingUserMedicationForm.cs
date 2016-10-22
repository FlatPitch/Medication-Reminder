using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class viewingUserMedicationForm : Form
    {
        public viewingUserMedicationForm()
        {
            InitializeComponent();
        }

        private void viewingUserMedicationForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Date
            ListViewItem list = new System.Windows.Forms.ListViewItem("08/10/16");
            //Name
            list.SubItems.Add("Jeremy");
            //Medication
            list.SubItems.Add("Moxicide");
            //Dosage
            list.SubItems.Add("2");
            //Time
            list.SubItems.Add("1:00PM");
            listView1.Items.Add(list);
        }
    }
}
