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
using MahApps.Metro.Controls;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OTRS_Ticket_Gen_v2_Rebirth
{
    /// <summary>
    /// Interaction logic for Email_Preview.xaml
    /// </summary>
    public partial class Email_Preview : MetroWindow
    {
        #region Variables
        private string head;
        private string body;
        private emailSent sent;
        private emailFail fail;
        #endregion

        public Email_Preview()
        {
            InitializeComponent();
        }
        public Email_Preview(string newHead, string newBody)
        {
            InitializeComponent();
            sent = new emailSent();
            fail = new emailFail();
            head = newHead;
            body = newBody;
        }
        private void b_send_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Outlook.Application application = new Microsoft.Office.Interop.Outlook.Application();
            Outlook.MailItem email = (Outlook.MailItem)application.CreateItem(Outlook.OlItemType.olMailItem);
            email.To = "Kyle.Avery@wsu.edu";
            email.Subject = head;
            email.Body = body;
            try
            {
                ((Outlook._MailItem)email).Send();
                sent.Show();
            }
            catch
            {
                fail.Show();
            }
        }

        private void b_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
        public void closeWindows()
        {
            sent.Close();
            fail.Close();
        }
    }
}
