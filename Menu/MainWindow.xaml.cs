using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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
using OTRS_Ticket_Gen_v2_Rebirth;

namespace Menu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : MetroWindow
    {

        #region Variables
        OTRS_Ticket_Gen_v2_Rebirth.MainWindow TG;
        BlacklistIPList.MainWindow BIP;
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            TG = new OTRS_Ticket_Gen_v2_Rebirth.MainWindow();
            BIP = new BlacklistIPList.MainWindow();
            TG.Hide();
            BIP.Hide();
        }
        void mainWindow_Closing(object sender, CancelEventArgs e)
        {
            TG.Close();
            BIP.Close();
        }

        private void b_TicketGen_Click(object sender, RoutedEventArgs e)
        {
            //if (!TG.IsActive)
            //{
            if (TG.Visibility == System.Windows.Visibility.Hidden)
                TG.Show();
            else
                TG.Hide();
            //}
            //else
            //    TG = new OTRS_Ticket_Gen_v2_Rebirth.MainWindow();
        }

        private void b_blacklist_Click(object sender, RoutedEventArgs e)
        {
            if (BIP.Visibility == System.Windows.Visibility.Hidden)
                BIP.Show();
            else
                BIP.Hide();
        }
    }
}
