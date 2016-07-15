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
        int k;
        public MainWindow()
        {
            InitializeComponent();
            InitLevelOfSpeed();
        }
        
        private int InitLevelOfSpeed()
        {
            k = 100; 
            k = (int)slider.Value;
            return k;
            //return k;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow1 main = new MainWindow1((int)slider.Value);
            //GameSpeed game = new MainWindow1.GameSpeed();
            //main.SpeedOfMainCharacter += TheSlider_ValueChanged;
            main.Show();
            this.Close();
        }
        public void TheSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {


   //         k = (int)slider.Value;

            System.Diagnostics.Debug.WriteLine(k);

        }
    }
}
