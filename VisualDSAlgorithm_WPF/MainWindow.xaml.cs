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
            ImageBrush b = new ImageBrush();
            b.ImageSource = new BitmapImage(new Uri("C:/Users/李博/Documents/Visual Studio 2017/Projects/VisualDSAlgorithm_WPF/VisualDSAlgorithm_WPF/background.png"));
            b.Stretch = Stretch.Fill;
            this.Background = b;
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

        private void Hyperlink_Click7(object sender, RoutedEventArgs e)
        {
            heap h = new heap();
            h.Show();
        }

        private void Hyperlink_Click8(object sender, RoutedEventArgs e)
        {
            RadixSort radixSort = new RadixSort();
            radixSort.Show();
        }
    }
}
