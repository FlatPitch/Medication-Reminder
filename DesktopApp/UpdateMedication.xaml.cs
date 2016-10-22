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
    /// Interaction logic for UpdateMedication.xaml
    /// </summary>
    public partial class UpdateMedication : Window
    {
        public UpdateMedication()
        {
            InitializeComponent();
        }

        private void updateUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if(updateUsername.Text != "")
            {
                string tempUsername = updateUsername.Text;
                //Call database validation here to validate input username.
                //if(Valid == true)
                //{
                    //Pass through input information into database for that user.
                    string medication = comboBox.Text;
                    int dosage = Int32.Parse(comboBox1.Text);
                    int time = Int32.Parse(timeTextBox.Text);
                    
                    MessageBox.Show("Medication for "+updateUsername.Text+" has been successfully updated");
                //}
                //else
                //{
                    MessageBox.Show("Error: Please enter a valid Username");
                //}
            }

        }
    }
}
