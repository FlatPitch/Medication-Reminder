using DesktopApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MedicationPC
{
    /// <summary>
    /// Interaction logic for ViewMedication.xaml
    /// </summary>
    public partial class ViewMedication : Window
    {
        public ViewMedication()
        {
            InitializeComponent();
        }

        private void viewButton_Click(object sender, RoutedEventArgs e)
        {
            if (viewUsername.Text != "")
            {
                //check databse and validate user entry.
                //if (valid == true)
                //{
                    new viewingUserMedicationForm().Show();
                    this.Hide();
                //}
                //else
                //{
                    MessageBox.Show("User: " + viewUsername.Text + " does not exist");
                //}
            }
            else
            {
                MessageBox.Show("");
            }
        }
    }
}
