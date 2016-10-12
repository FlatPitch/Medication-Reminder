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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MedicationPC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void button_click(object sender, RoutedEventArgs e)
        {
            AddUser user = new AddUser();
            user.ShowDialog();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            UpdateMedication meds = new UpdateMedication();
            meds.ShowDialog();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ViewMedication vMeds = new ViewMedication();
            vMeds.ShowDialog();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            RemoveUser rUser = new RemoveUser();
            rUser.ShowDialog();
        }
    }
}
