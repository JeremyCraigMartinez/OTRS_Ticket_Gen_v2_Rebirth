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
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace OTRS_Ticket_Gen_v2_Rebirth
{
    /// <summary>
    /// Interaction logic for MachineWindow.xaml
    /// </summary>
    public partial class MachineWindow : MetroWindow
    {
        public MachineWindow()
        {
            InitializeComponent();
        }

        private void b_MClose_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
