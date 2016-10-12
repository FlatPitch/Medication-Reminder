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
    /// Interaction logic for RemoveUser.xaml
    /// </summary>
    public partial class RemoveUser : Window
    {
        public RemoveUser()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if(remUsername.Text == "admin")
            {
                if(remPassword.Text == "admin")
                {
                    MessageBox.Show("The user: " + remUsername.Text + " has been successfully removed");
                }
                else
                {
                    MessageBox.Show("That user does not exist");
                }
            }
            else
            {
                MessageBox.Show("That user does not exist");
            }
        }
    } 
}
