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
    /// Interaction logic for TargetViewr.xaml
    /// </summary>
    public partial class TargetViewr : MetroWindow
    {
        #region Variables

        private MachineWindow MWindow;
        private List<Target> targetList;
        private List<int> targetPosition;
        private Index globalIndex;
        double width = 0, height = 0;
        int indexSelected = 0;

        #endregion

        public TargetViewr()
        {
            InitializeComponent();
            MWindow = new MachineWindow();
            System.Windows.Controls.DockPanel temp2 = new DockPanel();
            System.Windows.Controls.Label l = new Label();
            l.Content = "Send to Email";
            temp2.Children.Add(l);
            l = new Label();
            l.Content = "Target Overview";
            temp2.Children.Add(l);
            sp.Children.Add(temp2);
        }

        public TargetViewr(ref List<Target> list, ref List<int> pos, ref Index worldIndex)
        {
            InitializeComponent();
            targetList = list;
            targetPosition = pos;
            globalIndex = worldIndex;
            MWindow = new MachineWindow();
            MWindow.Hide();
            System.Windows.Controls.DockPanel temp2 = new DockPanel();
            System.Windows.Controls.Label l = new Label();
            l.Content = "Send to Email";
            l.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
            l.Arrange(new Rect(l.DesiredSize));
            width = l.ActualWidth;
            height = l.ActualHeight;
            temp2.Children.Add(l);
            l = new Label();
            l.Content = "Target Overview";
            temp2.Children.Add(l);
            sp.Children.Add(temp2);
            if (targetList.Count != 0)
            {
                foreach (Target t in targetList)
                {
                    /* Make sure the target hasn't been "deleted" */
                    if (!t._DELETE)
                    {
                        /* Dock Panel in a Stack Panel */
                        System.Windows.Controls.DockPanel temp = new DockPanel();
                        /* Check Box */
                        System.Windows.Controls.CheckBox newCheckBox = new CheckBox();
                        newCheckBox.Name = String.Format("cb_{0}", t._INDEX.ToString());
                        newCheckBox.Width = width;
                        newCheckBox.Height = height;
                        newCheckBox.IsChecked = t._SEND;
                        newCheckBox.Click += new RoutedEventHandler(checkBox_stateChanged);
                        temp.Children.Add(newCheckBox);
                        /* Button */
                        System.Windows.Controls.Button newBtn = new Button();
                        newBtn.Click += new RoutedEventHandler(button_Click);
                        newBtn.Name = String.Format("b_{0}", (list.Count - 1).ToString());
                        newBtn.Content = String.Format("{0} - {1} - {2}", t._IP, t._MAC, t._LOCATION);
                        temp.Children.Add(newBtn);
                        sp.Children.Add(temp);
                    }
                }
            }
        }
        public void refresh()
        {
            sp.Children.Clear();
            System.Windows.Controls.DockPanel temp2 = new DockPanel();
            System.Windows.Controls.Label l = new Label();
            l.Content = "Send to Email";
            l.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
            l.Arrange(new Rect(l.DesiredSize));
            width = l.ActualWidth;
            height = l.ActualHeight;
            temp2.Children.Add(l);
            l = new Label();
            l.Content = "Target Overview";
            temp2.Children.Add(l);
            sp.Children.Add(temp2);
            if (targetList.Count != 0)
            {
                foreach (Target t in targetList)
                {
                    /* Make sure the target hasn't been "deleted" */
                    if (!t._DELETE)
                    {
                        /* Dock Panel in a Stack Panel */
                        System.Windows.Controls.DockPanel temp = new DockPanel();
                        /* Check Box */
                        System.Windows.Controls.CheckBox newCheckBox = new CheckBox();
                        newCheckBox.Name = String.Format("cb_{0}", t._INDEX.ToString());
                        newCheckBox.Width = width;
                        newCheckBox.Height = height;
                        newCheckBox.IsChecked = t._SEND;
                        newCheckBox.Click += new RoutedEventHandler(checkBox_stateChanged);
                        temp.Children.Add(newCheckBox);
                        /* Button */
                        System.Windows.Controls.Button newBtn = new Button();
                        newBtn.Click += new RoutedEventHandler(button_Click);
                        newBtn.Name = String.Format("b_{0}", t._INDEX.ToString());
                        newBtn.Content = String.Format("{0} - {1} - {2}", t._IP, t._MAC, t._LOCATION);
                        temp.Children.Add(newBtn);
                        sp.Children.Add(temp);
                    }
                }
            }
        }
        protected void button_Click(object sender, EventArgs e)
        {
            Button pressed = sender as Button;
            string[] hold = pressed.Name.Split('_');
            int index = Convert.ToInt32(hold[1]);
            indexSelected = index; //Sets up for deleteion later
            l_targetP.Content = targetList[index].Meta();
        }
        protected void checkBox_stateChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            string[] hold = cb.Name.Split('_');
            int index = Convert.ToInt32(hold[1]);   //bug?
            if ((bool)cb.IsChecked)
            {
                targetList[index]._SEND = true;
            }
            else
                targetList[index]._SEND = false;
        }
        public void closeWindows()
        {
            MWindow.Close();
        }

        private void b_close_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void b_addTarget_Click(object sender, RoutedEventArgs e)
        {
            if (MWindow.Visibility == System.Windows.Visibility.Hidden)
            {
                MWindow.Close();
                MWindow = new MachineWindow(ref targetList, ref globalIndex, this);
                MWindow.Show();
            }
            else
                MWindow.Hide();
        }

        private void b_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                targetList[indexSelected]._DELETE = true;
                l_targetP.Content = String.Format("");
                indexSelected = 0;
                refresh();
            }
            catch
            {

            }
        }

        private void b_edit_Click(object sender, RoutedEventArgs e)
        {
            if (MWindow.Visibility == System.Windows.Visibility.Hidden)
            {
                if(targetList.Count != 0)
                {
                    MWindow.Close();
                    Target temp = targetList[indexSelected];
                    MWindow = new MachineWindow(ref temp, this);
                    MWindow.Show();
                }
            }
            else
                MWindow.Hide();
        }
    }
}
