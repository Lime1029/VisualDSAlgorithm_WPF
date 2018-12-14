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
        

        public StackL()
        {
            InitializeComponent();
        }

        

        private void Click_Push(object sender, RoutedEventArgs e)
        {
            input = textInput.Text;
            if (input.Length != 0)
            {
                movingNumver.Content = input;
                //创建DispatcherTimer对象
                System.Windows.Threading.DispatcherTimer tmr = new System.Windows.Threading.DispatcherTimer();
                //设置间隔时间
                tmr.Interval = TimeSpan.FromSeconds(0.1);
                //绑定函数
                tmr.Tick += new EventHandler(tmr_Tick);
                tmr.Start();//启动计时器
                

            }
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            t1.X = t1.X + 10;
            t1.Y = t1.Y + 5;
            if (t1.X > 50)
            {
                (sender as System.Windows.Threading.DispatcherTimer).Stop();
            }
        }
    }
}
