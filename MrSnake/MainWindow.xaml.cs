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

namespace MrSnake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Frontend obj { get; }
        public MainWindow()
        {
            InitializeComponent();
            obj = new Frontend();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            obj.start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            obj.resume();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            obj.pause();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            obj.kill();
        }
    }
}
