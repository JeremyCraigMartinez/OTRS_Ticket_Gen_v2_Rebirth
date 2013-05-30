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

namespace OTRS_Ticket_Gen_v2_Rebirth
{
    /// <summary>
    /// Interaction logic for MachineWindow.xaml
    /// </summary>
    public partial class MachineWindow : MetroWindow
    {
        #region Variables

        private Target currentT;
        private List<Target> targetList;
        private Index globalIndex;
        enum Type {normal, edit};
        Type type;
        TargetViewr parent;

        #endregion

        public MachineWindow()
        {
            InitializeComponent();
        }
        public MachineWindow(ref List<Target> t, ref Index worldIndex, TargetViewr PARENT)
        {
            InitializeComponent();
            targetList = t;
            globalIndex = worldIndex;
            parent = PARENT;
            type = Type.normal;
        }
        public MachineWindow(ref Target T, TargetViewr PARENT)
        {
            InitializeComponent();
            parent = PARENT;
            tb_IP.Text = T._IP;
            tb_MAC.Text = T._MAC;
            tb_userName.Text = T._userName;
            tb_Switch.Text = T._SWITCH;
            tb_Jack.Text = T._JACK;
            tb_source.Text = T._SOURCE;
            tb_message.Text = T._MESSAGE;
            tb_count.Text = T._COUNT;
            tb_dhcpD.Text = T._DHCPD;
            tb_dhcpC.Text = T._DHCPC;
            tb_Location.Text = T._LOCATION;
            tb_Room.Text = T._ROOM;
            tb_Resident.Text = T._RESIDENT;
            type = Type.edit;
            currentT = T;
        }
        private void b_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
        private void b_Add_Click(object sender, RoutedEventArgs e)
        {
            if (type == Type.normal)
            {
                bool skip = false;
                foreach (Target T in targetList)
                {
                    if (String.CompareOrdinal(T._MAC, tb_MAC.Text) == 0 && T._DELETE)
                    {
                        T._DELETE = false;
                        skip = true;
                    }
                    else if (String.CompareOrdinal(T._MAC, tb_MAC.Text) == 0 && !T._DELETE)
                        skip = true;
                }
                if (!skip)
                {
                    Target temp = new Target(tb_IP.Text, tb_MAC.Text, tb_userName.Text, tb_Switch.Text, tb_Jack.Text, tb_source.Text, tb_message.Text,
                        tb_count.Text, tb_dhcpD.Text, tb_dhcpC.Text, tb_Location.Text, tb_Room.Text, tb_Resident.Text, globalIndex.Indexer);
                    targetList.Add(temp);
                    globalIndex.Indexer++;
                }
            }
            else if(type == Type.edit)
            {
                currentT._IP = tb_IP.Text;
                currentT._MAC = tb_MAC.Text;
                currentT._userName = tb_userName.Text;
                currentT._SWITCH = tb_Switch.Text;
                currentT._JACK = tb_Jack.Text;
                currentT._SOURCE = tb_source.Text;
                currentT._MESSAGE = tb_message.Text;
                currentT._COUNT = tb_count.Text;
                currentT._DHCPD = tb_dhcpD.Text;
                currentT._DHCPC = tb_dhcpC.Text;
                currentT._LOCATION = tb_Location.Text;
                currentT._ROOM = tb_Room.Text;
                currentT._RESIDENT = tb_Resident.Text;
            }
            parent.refresh();
            this.Hide();
        }
    }
}
