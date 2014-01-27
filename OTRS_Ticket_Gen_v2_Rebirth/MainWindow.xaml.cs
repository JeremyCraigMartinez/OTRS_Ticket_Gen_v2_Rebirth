using System;
using System.ComponentModel;
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
        private string emailBody;
        private string head;
        private Email_Preview preview;
        private TargetViewr TVWindow;
        private List<Target> machineList;
        private List<int> machineNumber;
        private blacklist blWindow;
        Index machineIndex;
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            machineList = new List<Target>();
            machineNumber = new List<int>();
            machineIndex = new Index();
            OVWindow = new OverViewWindow();
            CWindow = new Credentials();
            TVWindow = new TargetViewr();
            RWindow = new RecommendationWindow();
            preview = new Email_Preview();
            blWindow = new blacklist();
            emailBody = "";
            head = "";
            OVWindow.Hide();
            CWindow.Hide();
            RWindow.Hide();
            preview.Hide();
            TVWindow.Hide();
            blWindow.Hide();
        }
        private void b_otrs_send(object sender, RoutedEventArgs e)
        {
            if (preview.Visibility == System.Windows.Visibility.Hidden)
            {
                head = pullHead();
                emailBody = pullBody();
                preview.closeWindows();
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
            //OVWindow.Close();
            //CWindow.Close();
            //RWindow.Close();
            //preview.closeWindows();
            //preview.Close();
            //TVWindow.closeWindows();
            //TVWindow.Close();
            //blWindow.Close();
            //this.Close();
            this.Hide();
        }
        private void b_clear_Click(object sender, RoutedEventArgs e)
        {
            /* Clear the Overview Window */
            OVWindow.cb_securityAlertLevel.Text = "";
            OVWindow.cb_securityAlertType.Text = "";
            OVWindow.tb_date.Text = "";
            OVWindow.tb_duration.Text = "";
            OVWindow.tb_time.Text = "";
            OVWindow.cb_initial.Text = "";
            /* Clear the Recomendations Window */
            RWindow.cb_Containment.Text = "";
            RWindow.cb_Investigation.Text = "";
            RWindow.cb_Preservation.Text = "";
            RWindow.cb_Remediation.Text = "";
            /* Clear the Machine Window */
            machineList.Clear();
            /* Clear Email Preview */
            preview.tb_emailPV.Text = "";
            /* Clear the blacklisted information */
            blWindow.tb_blIP.Text = "";
            blWindow.tb_confidence.Text = "";
            blWindow.tb_descr.Text = "";
            /* Reset the Index on Clear */
            machineIndex = new Index();
            machineList.Clear();
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
            if (TVWindow.Visibility == System.Windows.Visibility.Hidden)
            {
                TVWindow.closeWindows();
                TVWindow.Close();
                TVWindow = new TargetViewr(ref machineList, ref machineNumber, ref machineIndex);
                TVWindow.Show();
            }
            else
                TVWindow.Hide();
        }
        private string pullBody()
        {
            string output = "";
            /* Overview Window */
            output = String.Format("Overview\nSecurity Alert Rating:\t{0}\nSecurity Alert Type:\t{1}\nInitial Indicator:\t\t{2}\n" +
                "Date:\t\t\t{3}\nTime:\t\t\t{4}\nDuration:\t\t{5}\n\n", 
                OVWindow.cb_securityAlertLevel.Text, OVWindow.cb_securityAlertType.Text, OVWindow.cb_initial.Text, 
                OVWindow.tb_date.Text, OVWindow.tb_time.Text, OVWindow.tb_duration.Text);
            /* Target Information */
            output += String.Format("Suspect System Information\n");
            foreach(Target T in machineList)
            {
                if(!T._DELETE && T._SEND)
                    output += T.emailFormat();
            }
            /* Blacklisted Information */
            output += String.Format("{0} Synopsis\nConfidence Level in the assessment: {1}%\n", OVWindow.cb_securityAlertType.Text, blWindow.tb_confidence.Text);
            if (blWindow.tb_blIP.Text != "")
            {
                string[] temp = blWindow.tb_blIP.Text.Split(new string[] { "\r\n", ",", ", ", ";", "; ", " " }, StringSplitOptions.RemoveEmptyEntries);
                output += String.Format("This machine has been observed reaching out to the following known malicious addresses: ");
                bool first = true;
                foreach (string s in temp)
                {
                    if (first)
                    {
                        output += String.Format("{0}", s);
                        first = false;
                    }
                    else
                    {
                        output += String.Format(", ");
                        output += String.Format("{0}", s);
                    }
                }
                output += String.Format(".");
            }
            if (blWindow.tb_descr.Text != "")
                output += String.Format("\n{0}", blWindow.tb_descr.Text);
            else
                output += String.Format("\n[Describe The Behavior Observed]");
            /* Recommendations */
            output += String.Format("\n\nRecommendations\nTake the following actions in the outlined order:\n");
            if (RWindow.cb_Preservation.Text != "None" && RWindow.cb_Preservation.Text != "")
                output += String.Format("Preservation: {0} - ", RWindow.cb_Preservation.Text);
            switch (RWindow.cb_Preservation.Text)
            {
                case "PCAP":
                    output += String.Format("A packet capture, consists of an application programming interface for capturing network traffic. " + 
                        "For monitoring the packets one of the tools that we use is WireShark and it may come in handy for you too.\n\n");
                    break;
                case "Memory Image":
                    output += String.Format("A Memory Image is an exact replica of the machine's RAM memory at that time. We recommend using FTK Imager Lite to capture the memory image.\n\n");
                    break;
                case "Disk Image":
                    output += String.Format("A disk image is an exact replica of the machine's hard drive. One tool we use for disk imaging is FTK Imager Lite. Any other program that images disks we recommend that it images in bit for bit format to capture, and prefereable puts the disk image into a read only format.\n\n");
                    break;
                //case "None":
                //    output += String.Format("In this case no specific preservation is recommended.\n\n");
                //    break;
            }
            if (RWindow.cb_Containment.Text != "None" && RWindow.cb_Containment.Text != "")
                output += String.Format("Containment: {0} - ", RWindow.cb_Containment.Text);
            switch(RWindow.cb_Containment.Text)
            {
                case "Network Disconnect - Link Termination":
                    output += String.Format("Cutting off network access will prevent the network activity from continuing as well as prevent any command and control communications that are taking place. So simply remove the machine's lan cable and/or turn of the machine's wireless capabilities.\n\n");
                    break;
                case "Network Disconnect - Null Route":
                    output += String.Format("A null route is a network route that goes nowhere or is a forwarded to an illegal IP address. To achieve a null route configure the IP with a special route flag, or forward the packets to an illegal route such as 0.0.0.0.\n\n");
                    break;
                case "Power Off The Machine":
                    output += String.Format("Due to spreading malicious traffic from this machine, please turn it off and remove it from the network.\n\n");
                    break;
                //case "None":
                //    output += String.Format("In this case no specific containment is recommended.\n\n");
                //    break;
            }
            if (RWindow.cb_Investigation.Text != "None" && RWindow.cb_Investigation.Text != "")
                output += String.Format("Investigation: {0} - ", RWindow.cb_Investigation.Text);
            switch (RWindow.cb_Investigation.Text)
            {
                case "Offline Anti - Malware Scan":
                    output += String.Format("After taking the system offline run an AV scan. One tool that we have found useful is Windows Defender Offline during this process.\n\n");
                    break;
                case "Log Review":
                    output += String.Format("Review any available logs from the network and system.\n\n");
                    break;
                case "Network Traffic Analysis":
                    output += String.Format("Review any available logs from the network and system.\n\n");
                    break;
                case "Forensic Drive / Memory Analysis":
                    output += String.Format("Analyze the data that was gained from imaging the machine, and find the source of the issue.\n\n");
                    break;
                //case "None":
                //    output += String.Format("In this case no specififc investigation is recommended.\n\n");
                //    break;
            }
            if (RWindow.cb_Remediation.Text != "None" && RWindow.cb_Remediation.Text != "")
                output += String.Format("Remediation: {0} - ", RWindow.cb_Remediation.Text);
            switch (RWindow.cb_Remediation.Text)
            {
                case "System Rebuild":
                    output += String.Format("Due to the stealthy nature of the malware an AV scan is highly unlikely to capture all of the infection. So a full system rebuild or restore is recommended in order to get the machine back to a clean state.\n\n");
                    break;
                case "Anti-Malware Clean-Up":
                    output += String.Format("Using your preffered offline AV software remove any malicious items from the computer.\n\n");
                    break;
                case "Data Sanitization":
                    output += String.Format("Due to the stealthy nature of the malware an AV scan is highly unlikely to capture all of the infection. In this case a full system rebuild is recommended because the personal data is highly likley to be infected and can't be risked moving the infection back into a new clean system.\n\n");
                    break;
                //case "None":
                //    output += String.Format("In this case no specific remediation is recommended.\n\n");
                //    break;
            }
            output += String.Format("\nPrevention: [Insert Prevention Ideas Here]\n\nPlease remember to email the Network Security Team back with the findings or if you have any further questions!\n\n" + 
                "Thank You,\n{0}\n{1}", CWindow.tb_name.Text, CWindow.tb_phoneNumber.Text);
            return output;
        }
        private string pullHead()
        {
            if (machineList.Count != 0)
            {
                int target_count = 0;
                int target = 0;
                if (machineList.Count > 1)
                {
                    foreach (Target T in machineList)
                        if (T._SEND == true)
                        {
                            target_count++;
                            target = T._INDEX;
                        }
                }
                else
                {
                    target_count = 1;
                    target = 0;
                }
                string output = "";
                output = String.Format("Network Security Notification - {0}", OVWindow.cb_securityAlertType.Text);
                if (target_count == 1)
                    output += String.Format(" - {0} - {1} - {2}", machineList[target]._IP, machineList[target]._MAC, machineList[target]._LOCATION);
                else
                    output += String.Format(" - multiple suspect systems - {0}", machineList[0]._LOCATION);
                return output;
            }
            else
                return "";
        }

        private void b_b_Click(object sender, RoutedEventArgs e)
        {
            if (blWindow.Visibility == System.Windows.Visibility.Hidden)
                blWindow.Show();
            else
                blWindow.Hide();
        }
        void mainWindow_Closing(object sender, CancelEventArgs e)
        {
            OVWindow.Close();
            CWindow.Close();
            RWindow.Close();
            preview.closeWindows();
            preview.Close();
            TVWindow.closeWindows();
            TVWindow.Close();
            blWindow.Close();
        }
    }
}
