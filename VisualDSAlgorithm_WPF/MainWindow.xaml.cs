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

namespace VisualDSAlgorithm_WPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click1(object sender, RoutedEventArgs e)
        {
            stackArray stackarray = new stackArray();
            stackarray.Show();
        }

        private void Hyperlink_Click2(object sender, RoutedEventArgs e)
        {
            StackL stackL = new StackL();
            stackL.Show();
        }

        private void Hyperlink_Click3(object sender, RoutedEventArgs e)
        {
            queueArray queuearray = new queueArray();
            queuearray.Show();
        }

        private void Hyperlink_Click4(object sender, RoutedEventArgs e)
        {
            QueueL queueL = new QueueL();
            queueL.Show();
        }

        private void Hyperlink_Click5(object sender, RoutedEventArgs e)
        {
            SearchN searchN = new SearchN();
            searchN.Show();
        }

        private void Hyperlink_Click6(object sender, RoutedEventArgs e)
        {
            ComparingSort comparingSort = new ComparingSort();
            comparingSort.Show();
        }
    }
}
