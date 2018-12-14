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
using System.Windows.Media.Animation;

namespace VisualDSAlgorithm_WPF
{
    /// <summary>
    /// StackL.xaml 的交互逻辑
    /// </summary>
    public partial class StackL : Window
    {
        string input;
        //Label movingNumber, label1, label2, label3 = new Label();

        public StackL()
        {
            InitializeComponent();
        }

        

        private void Click_Push(object sender, RoutedEventArgs e)
        {
            input = textInput.Text;
            if (input.Length != 0)
            {

                /*DoubleAnimation da = new DoubleAnimation();
                Label movingNumber = new Label();
                movingNumber.Margin = new Thickness(10, 10, 0, 0);
                movingNumber.Content = input;
                background.Children.Add(movingNumber);
                /*da.From = movingNumber.Margin.Left;
                da.To = 300;
                da.Duration = new Duration(TimeSpan.FromSeconds(5));
                movingNumber.BeginAnimation(Label.MarginProperty, da);
                DoubleAnimation da = new DoubleAnimation();
                da.From = label.Margin.Left;
                da.To = 300;
                da.Duration = new Duration(TimeSpan.FromSeconds(5));
                label.BeginAnimation(Label.MarginProperty, da);*/


            }
        }
    }
}
