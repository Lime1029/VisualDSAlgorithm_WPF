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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace VisualDSAlgorithm_WPF
{
    /// <summary>
    /// SearchN.xaml 的交互逻辑
    /// </summary>
    public partial class SearchN : Window
    {
        //设置代理函数
        public delegate int ContinueDelegate();

        //设置标记
        private bool continueShow = false;
        //private Storyboard myStoryboard;


        //设置用户想要程序停止运行
        bool wantStop = false;

        //用户想要查找的数
        int value = 743;

        double speed = 1000;

        public SearchN()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            speed = Convert.ToDouble(speedBox.Text);
            R1label.Content = "";
            binarySort.Visibility = Visibility.Visible;
            binaryInfo.Visibility = Visibility.Visible;
            linerSort.Visibility = Visibility.Hidden;
            linerInfo.Visibility = Visibility.Hidden;
            button1.IsEnabled = false;
            if (textBox.Text.Length == 0)
            {
                textBox.Text = 743.ToString();
            }
            value = Convert.ToInt32(textBox.Text);
            Slabel.Content = textBox.Text;
            button1.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new ContinueDelegate(binaryShow));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            speed = Convert.ToDouble(speedBox.Text);
            linerSort.Visibility = Visibility.Visible;
            linerInfo.Visibility = Visibility.Visible;
            binaryInfo.Visibility = Visibility.Hidden;
            binarySort.Visibility = Visibility.Hidden;
            button.IsEnabled = false;
            if (textBox.Text.Length == 0)
            {
                textBox.Text = 743.ToString();
            }
            value = Convert.ToInt32(textBox.Text);
            Slabel.Content = textBox.Text;
            //liner sort 线性查找的内容
            /*if (continueShow)
            {
                continueShow = false;
                button.Content = "resume";
            }
            else
            {
                continueShow = true;
                button.Content = "stop";
                button.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new ContinueDelegate(show));
            }*/
            button.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new ContinueDelegate(linerShow));
        }

        private int linerShow()
        {
            int[] sort = { 1, 23, 24, 68, 97, 103, 104, 152, 157, 160, 161, 181, 192, 217, 226, 260, 269, 339, 365, 459, 529, 540, 579, 585, 632, 668, 712, 743 };
            int index = 0;
            String ellipseName;
            String labelName;
            Object label;
            ellipseName = "ellipse" + index.ToString();
            Object ellipse = this.GetType().GetField(ellipseName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
            Ilabel.BorderBrush = new SolidColorBrush(Colors.Red);
            codelabel2.Foreground = new SolidColorBrush(Colors.Red);
            ((Ellipse)ellipse).Opacity = 1.0;
            Ilabel.Content = index.ToString();
            var t = DateTime.Now.AddMilliseconds(speed);
            wait();
            codelabel2.Foreground = new SolidColorBrush(Colors.Black);
            ((Ellipse)ellipse).Opacity = 0.0;

            //while循环部分
            codelabel3.Foreground = new SolidColorBrush(Colors.Red);
            wait();
            codelabel3.Foreground = new SolidColorBrush(Colors.Black);

            //停止
            if (wantStop)
            {
                button.IsEnabled = true;
                wantStop = false;
                return 0;
            }

            while (index < sort.Length && sort[index] < value)
            {

                labelName = "label" + index.ToString();
                label = this.GetType().GetField(labelName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                ((Label)label).BorderBrush = new SolidColorBrush(Colors.Red);
                ((Label)label).BorderThickness = new Thickness(3);
                Slabel.BorderBrush = new SolidColorBrush(Colors.Red);
                codelabel3.Foreground = new SolidColorBrush(Colors.Red);
                wait();
                codelabel3.Foreground = new SolidColorBrush(Colors.Black);
                Slabel.BorderBrush = new SolidColorBrush(Colors.Black);
                ((Label)label).BorderBrush = new SolidColorBrush(Colors.Black);
                ((Label)label).BorderThickness = new Thickness(1);
                wait();

                //stop
                if (wantStop)
                {
                    button.IsEnabled = true;
                    wantStop = false;
                    return 0;
                }
                //index++;
                index++;
                codelabel4.Foreground = new SolidColorBrush(Colors.Red);
                ellipseName = "ellipse" + index.ToString();

                if (index < sort.Length)
                {
                    ellipse = this.GetType().GetField(ellipseName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                    ((Ellipse)ellipse).Opacity = 1.0;
                }

                Ilabel.Content = index.ToString();
                Ilabel.BorderBrush = new SolidColorBrush(Colors.Blue);
                wait();
                codelabel4.Foreground = new SolidColorBrush(Colors.Black);
                Ilabel.BorderBrush = new SolidColorBrush(Colors.Black);
                if (index < sort.Length)
                {
                    ((Ellipse)ellipse).Opacity = 0.0;
                }


                //
                if (wantStop)
                {
                    button.IsEnabled = true;
                    wantStop = false;
                    return 0;
                }

                //暂停操作
                /*if (continueShow)
                {
                    button.Dispatcher.BeginInvoke(
                    System.Windows.Threading.DispatcherPriority.SystemIdle,
                    new ContinueDelegate(this.show));
                }*/
            }

            codelabel5.Foreground = new SolidColorBrush(Colors.Red);
            labelName = "label" + index.ToString();
            if (index < sort.Length)
            {
                label = this.GetType().GetField(labelName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                ((Label)label).BorderBrush = new SolidColorBrush(Colors.Red);
                ((Label)label).BorderThickness = new Thickness(3);
            }

            Slabel.BorderBrush = new SolidColorBrush(Colors.Red);
            wait();
            codelabel5.Foreground = new SolidColorBrush(Colors.Black);
            if (index < sort.Length)
            {
                label = this.GetType().GetField(labelName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                ((Label)label).BorderBrush = new SolidColorBrush(Colors.Black);
                ((Label)label).BorderThickness = new Thickness(1);
            }

            Slabel.BorderBrush = new SolidColorBrush(Colors.Black);
            if (index >= sort.Length || sort[index] != value)
            {
                codelabel6.Foreground = new SolidColorBrush(Colors.Red);
                Rlabel.BorderBrush = new SolidColorBrush(Colors.Red);
                Rlabel.Content = (-1).ToString();
                R1label.Content = "can't find the result";
                wait();
                codelabel6.Foreground = new SolidColorBrush(Colors.Black);
                Rlabel.BorderBrush = new SolidColorBrush(Colors.Black);
                return -1;
            }
            codelabel7.Foreground = new SolidColorBrush(Colors.Red);
            Rlabel.BorderBrush = new SolidColorBrush(Colors.Red);
            Rlabel.Content = index.ToString();
            R1label.Content = "";
            wait();
            codelabel7.Foreground = new SolidColorBrush(Colors.Black);
            Rlabel.BorderBrush = new SolidColorBrush(Colors.Black);
            button.IsEnabled = true;
            return index;
        }

        private int binaryShow()
        {
            int[] sort = { 1, 23, 24, 68, 97, 103, 104, 152, 157, 160, 161, 181, 192, 217, 226, 260, 269, 339, 365, 459, 529, 540, 579, 585, 632, 668, 712, 743 };
            codelabel12.Foreground = new SolidColorBrush(Colors.Red);
            wait();
            int low = 0;
            int high = sort.Length - 1;
            int mid = (low + high) / 2;
            setLow(low);
            codelabel12.Foreground = new SolidColorBrush(Colors.Black);
            codelabel13.Foreground = new SolidColorBrush(Colors.Red);
            /*int high = sort.Length - 2;
            int mid=(low+high)/2;*/
            cancelLow(low);
            setHigh(high);
            setLow(low);
            codelabel13.Foreground = new SolidColorBrush(Colors.Black);
            codelabel14.Foreground = new SolidColorBrush(Colors.Red);
            wait();
            if (wantStop)
            {
                clear(mid, low, high);
                button1.IsEnabled = true;
                return 0;
            }
            while (low <= high)
            {
                if (wantStop)
                {
                    codelabel14.Foreground = new SolidColorBrush(Colors.Black);
                    clear(mid, low, high);
                    button1.IsEnabled = true;
                    return 0;
                }
                codelabel14.Foreground = new SolidColorBrush(Colors.Black);
                codelabel15.Foreground = new SolidColorBrush(Colors.Red);
                mid = (low + high) / 2;
                setMid(mid);
                codelabel15.Foreground = new SolidColorBrush(Colors.Black);
                codelabel16.Foreground = new SolidColorBrush(Colors.Red);
                setComapre(mid);
                if (sort[mid] == value)
                {
                    codelabel16.Foreground = new SolidColorBrush(Colors.Black);
                    cancelCompare(mid);
                    codelabel17.Foreground = new SolidColorBrush(Colors.Red);
                    Rlabel.Content = mid.ToString();
                    wait();
                    codelabel17.Foreground = new SolidColorBrush(Colors.Black);
                    cancelLow(low);
                    cancelHigh(high);
                    cancelMid(mid);
                    button1.IsEnabled = true;
                    return mid;
                }
                else
                {
                    codelabel16.Foreground = new SolidColorBrush(Colors.Black);
                    codelabel18.Foreground = new SolidColorBrush(Colors.Red);
                    wait();
                    codelabel18.Foreground = new SolidColorBrush(Colors.Black);
                    if (sort[mid] < value)
                    {
                        codelabel19.Foreground = new SolidColorBrush(Colors.Red);
                        cancelCompare(mid);
                        cancelLow(low);
                        low = mid + 1;
                        cancelMid(mid);
                        if (low <= sort.Length - 1)
                        {
                            setLow(low);
                        }

                        codelabel19.Foreground = new SolidColorBrush(Colors.Black);
                    }
                    else
                    {
                        codelabel20.Foreground = new SolidColorBrush(Colors.Red);
                        cancelCompare(mid);
                        cancelHigh(high);
                        codelabel20.Foreground = new SolidColorBrush(Colors.Black);
                        codelabel21.Foreground = new SolidColorBrush(Colors.Red);
                        high = mid - 1;
                        cancelMid(mid);
                        setHigh(high);
                        codelabel21.Foreground = new SolidColorBrush(Colors.Black);
                    }
                }
            }
            codelabel22.Foreground = new SolidColorBrush(Colors.Red);
            wait();
            codelabel22.Foreground = new SolidColorBrush(Colors.Black);
            if (low <= sort.Length - 1)
            {
                cancelLow(low);
            }
            cancelMid(mid);
            cancelHigh(high);
            Rlabel.Content = (-1).ToString();
            R1label.Content = "can't find the number";
            button1.IsEnabled = true;
            return -1;
        }

        private void setLow(int index)
        {
            String ellipseName = "ellipse" + index.ToString();
            Object ellipse = this.GetType().GetField(ellipseName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
            if (ellipse == null)
            {
                return;
            }
            ((Ellipse)ellipse).Opacity = 1.0;
            ((Ellipse)ellipse).Stroke = new SolidColorBrush(Colors.Blue);
            lowlabel.BorderThickness = new Thickness(3);
            lowlabel.Content = index.ToString();
            wait();
        }

        private void cancelLow(int index)
        {
            String ellipseName = "ellipse" + index.ToString();
            Object ellipse = this.GetType().GetField(ellipseName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
            ((Ellipse)ellipse).Opacity = 0.0;
            lowlabel.BorderThickness = new Thickness(1);
            wait();
        }

        private void setMid(int index)
        {
            String ellipseName = "ellipse" + index.ToString();
            Object ellipse = this.GetType().GetField(ellipseName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
            ((Ellipse)ellipse).Opacity = 1.0;
            ((Ellipse)ellipse).Stroke = new SolidColorBrush(Colors.Green);
            midlabel.BorderThickness = new Thickness(3);
            midlabel.Content = index.ToString();
            wait();
        }

        private void cancelMid(int index)
        {
            String ellipseName = "ellipse" + index.ToString();
            Object ellipse = this.GetType().GetField(ellipseName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
            ((Ellipse)ellipse).Opacity = 0.0;
            midlabel.BorderThickness = new Thickness(1);
            wait();
        }

        private void setHigh(int index)
        {
            String ellipseName = "ellipse" + index.ToString();
            Object ellipse = this.GetType().GetField(ellipseName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
            ((Ellipse)ellipse).Opacity = 1.0;
            ((Ellipse)ellipse).Stroke = new SolidColorBrush(Colors.Orange);
            highlabel.BorderThickness = new Thickness(3);
            highlabel.Content = index.ToString();
            wait();
        }

        private void cancelHigh(int index)
        {
            String ellipseName = "ellipse" + index.ToString();
            Object ellipse = this.GetType().GetField(ellipseName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
            ((Ellipse)ellipse).Opacity = 0.0;
            highlabel.BorderThickness = new Thickness(1);
            wait();
        }

        private void setComapre(int index)
        {
            String labelName = "label" + index.ToString();
            Object label = this.GetType().GetField(labelName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
            ((Label)label).BorderBrush = new SolidColorBrush(Colors.Red);
            ((Label)label).BorderThickness = new Thickness(3);
            Slabel.BorderBrush = new SolidColorBrush(Colors.Red);
            Slabel.BorderThickness = new Thickness(3);
            wait();
        }

        private void cancelCompare(int index)
        {
            String labelName = "label" + index.ToString();
            Object label = this.GetType().GetField(labelName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
            ((Label)label).BorderBrush = new SolidColorBrush(Colors.Black);
            ((Label)label).BorderThickness = new Thickness(1);
            Slabel.BorderBrush = new SolidColorBrush(Colors.Black);
            Slabel.BorderThickness = new Thickness(1);
            wait();
        }

        private void clear(int mid, int low, int high)
        {
            cancelCompare(mid);
            cancelHigh(high);
            cancelMid(mid);
            cancelLow(low);
            wantStop = false;
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            wantStop = true;
        }

        private void wait()
        {
            var t = DateTime.Now.AddMilliseconds(speed);
            while (DateTime.Now < t)
                DispatcherHelper.DoEvents();
        }
    }
}
