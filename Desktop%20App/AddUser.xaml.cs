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
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if(Username.Text == "admin")
            {
                if (password.Text == "admin")
                {
                    new clickaddUser().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error: Please enter a valid Username and Password");
                }
              
            }
            else
            {
                MessageBox.Show("Error: Please enter a valid Username and Password");
            }
        }

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
