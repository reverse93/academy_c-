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

namespace apka
{

    
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public delegate int ControlSpeedrHandler(int controlSpeed);
        //public event ControlSpeedrHandler ControlSpeedChanged;
        int k;
        //  int k;
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow1 main; 

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //int someData;
            //someData = InitLevelOfSpeed();
            //   MainWindow1 main = new MainWindow1(k);
            main = new MainWindow1();
            main.SetSpeed(k);
           /// main.Owner = this;
           
            main.Show();
            this.Close();
        }
        public void TheSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            k = (int)slider.Value;
            if (label1 != null)
            {
                if (k == 100)
                {
                    label1.Content = "trudny";
                }
                if(k == 500)
                {
                    label1.Content = "średni";
                }
                if (k == 900)
                {
                    label1.Content = " łatwy"; 
                }
                if (k == 1200)
                {
                    label1.Content = "bardzo prosty";
                }
            }
            if (main != null) main.SetSpeed((int)slider.Value);
            System.Diagnostics.Debug.WriteLine(k);

        }
    }
}
