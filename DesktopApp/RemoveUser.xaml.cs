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
            if(remUsername.Text != "")
            {
                if(remPassword.Text != "")
                {
                    string tempUsername = remUsername.Text;
                    string tempPassword = remPassword.Text;

                    //Add/call database functionality here to check if the entered strings match a user in the database.

                    //if(Valid = true)
                    //{
                        //Database function to remove the entered user.
                        MessageBox.Show("The user " + remUsername.Text + " has been successfully removed");
                    //}
                    //else
                    //{
                        MessageBox.Show(remUsername.Text + " is not a valid user");
                    //}
                }
                else
                {
                    MessageBox.Show("Please enter a valid Password");
                }
            }
            else if (remUsername.Text == "" && remPassword.Text == "")
            {
                MessageBox.Show("Please enter a valid Username and Password");
            }
            else
            {
                MessageBox.Show("Please enter a valid Username");
            }
        }
    } 
}
