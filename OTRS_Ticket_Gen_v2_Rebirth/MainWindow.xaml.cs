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
        private string emailBody;
        private string head;
        private Email_Preview preview;
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            OVWindow = new OverViewWindow();
            CWindow = new Credentials();
            RWindow = new RecommendationWindow();
            MWindow = new MachineWindow();
            preview = new Email_Preview();
            emailBody = "";
            head = "";
            MWindow.Hide();
            OVWindow.Hide();
            CWindow.Hide();
            RWindow.Hide();
            preview.Hide();
        }
        private void b_otrs_send(object sender, RoutedEventArgs e)
        {
            if (preview.Visibility == System.Windows.Visibility.Hidden)
            {
                head = pullHead();
                emailBody = pullBody();
                preview.Close();
                preview = new Email_Preview(head, emailBody);
                preview.Show();
            }
            else
                preview.Hide();
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
            string ep = this.GetChildObjects().ToString();
            OVWindow.Close();
            CWindow.Close();
            RWindow.Close();
            MWindow.Close();
            preview.closeWindows();
            preview.Close();
            string ex = this.GetChildObjects().ToString();
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
            /* Clear the Recomendations Window */
            RWindow.cb_Containment.Text = "";
            RWindow.cb_Investigation.Text = "";
            RWindow.cb_Preservation.Text = "";
            RWindow.cb_Remediation.Text = "";
            /* Clear the Machine Window */
            MWindow.tb_count.Text = "";
            MWindow.tb_dhcpC.Text = "";
            MWindow.tb_dhcpD.Text = "";
            MWindow.tb_IP.Text = "";
            MWindow.tb_Jack.Text = "";
            MWindow.tb_Location.Text = "";
            MWindow.tb_MAC.Text = "";
            MWindow.tb_message.Text = "";
            MWindow.tb_OffenseNumber.Text = "";
            MWindow.tb_Resident.Text = "";
            MWindow.tb_Room.Text = "";
            MWindow.tb_source.Text = "";
            MWindow.tb_Switch.Text = "";
            MWindow.tb_userName.Text = "";
            MWindow.tb_blacklisted.Text = "";
            /* Clear Email Preview */
            preview.tb_emailPV.Text = "";
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
        private string pullBody()
        {
            string output = "";
            return output;
        }
        private string pullHead()
        {
            string output = "";
            output = String.Format("{0} - {1} - Network Security Notification", MWindow.tb_IP.Text, MWindow.tb_MAC.Text);
            return output;
        }
    }
}
