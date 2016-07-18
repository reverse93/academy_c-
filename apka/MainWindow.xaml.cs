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
           // InitLevelOfSpeed();
        }

        public MainWindow1 main; 
       /* public void InitLevelOfSpeed()
        {
            int controlSpeed;
            controlSpeed = k;
            
        }*/

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //int someData;
            //someData = InitLevelOfSpeed();
            //   MainWindow1 main = new MainWindow1(k);
            main = new MainWindow1();
           /// main.Owner = this;
           
            main.Show();
            this.Close();
        }
        public void TheSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {


            k = (int)slider.Value;
            if (main != null) main.SetSpeed((int)slider.Value);
            System.Diagnostics.Debug.WriteLine(k);

        }
    }
}
