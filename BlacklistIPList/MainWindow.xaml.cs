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
using MahApps.Metro.Controls;

namespace BlacklistIPList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void b_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void b_Compile_Click(object sender, RoutedEventArgs e)
        {
            string output = String.Format("");
            string[] temp = tb_IPs.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var distinctIPs = new List<string>(temp.Distinct());
            foreach (string s in distinctIPs)
            {
                output += String.Format("{0}\r\n", s);
            }
            Clipboard.SetText(output);
        }
    }
}
