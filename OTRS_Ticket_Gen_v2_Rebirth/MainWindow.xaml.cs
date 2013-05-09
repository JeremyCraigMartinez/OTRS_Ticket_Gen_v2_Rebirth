﻿using System;
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
using Outlook = Microsoft.Office.Interop.Outlook;
using MahApps.Metro.Controls;

namespace OTRS_Ticket_Gen_v2_Rebirth
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        #region Variables
        private OverViewWindow OVWindow;
        private Credentials CWindow;
        private RecommendationWindow RWindow;
        private MachineWindow MWindow;
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            OVWindow = new OverViewWindow();
            CWindow = new Credentials();
            RWindow = new RecommendationWindow();
            MWindow = new MachineWindow();
            MWindow.Hide();
            OVWindow.Hide();
            CWindow.Hide();
            RWindow.Hide();
        }
        private void b_otrs_send(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Outlook.Application application = new Microsoft.Office.Interop.Outlook.Application();
            Outlook.MailItem email = (Outlook.MailItem)application.CreateItem(Outlook.OlItemType.olMailItem);
            email.To = "Kyle.Avery@wsu.edu";
            email.Subject = "Test";
            email.Body = "Test please ignore";
            ((Outlook._MailItem)email).Send();           
        }

        private void b_overview_Click(object sender, RoutedEventArgs e)
        {
            if (OVWindow.Visibility == System.Windows.Visibility.Hidden)
                OVWindow.Show();
            else
                OVWindow.Hide();
            
        }
        private void b_credentials(object sender, RoutedEventArgs e)
        {
            if (CWindow.Visibility == System.Windows.Visibility.Hidden)
                CWindow.Show();
            else
                CWindow.Hide();
        }
        private void b_exit_Click(object sender, RoutedEventArgs e)
        {
            OVWindow.Close();
            CWindow.Close();
            RWindow.Close();
            MWindow.Close();
            this.Close();
        }

        private void b_clear_Click(object sender, RoutedEventArgs e)
        {
            /* Clear the Overview Window */
            OVWindow.cb_securityAlertLevel.Text = "";
            OVWindow.cb_securityAlertType.Text = "";
            OVWindow.tb_date.Text = "";
            OVWindow.tb_duration.Text = "";
            OVWindow.tb_time.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (RWindow.Visibility == System.Windows.Visibility.Hidden)
                RWindow.Show();
            else
                RWindow.Hide();
        }

        private void b_machine_Click(object sender, RoutedEventArgs e)
        {
            if (MWindow.Visibility == System.Windows.Visibility.Hidden)
                MWindow.Show();
            else
                MWindow.Hide();
        }
    }
}
