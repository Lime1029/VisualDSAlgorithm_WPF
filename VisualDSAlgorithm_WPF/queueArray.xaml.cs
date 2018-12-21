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

namespace VisualDSAlgorithm_WPF
{
    /// <summary>
    /// queueArray.xaml 的交互逻辑
    /// </summary>
    public partial class queueArray : Window
    {
        private static int head = 0;
        private static int tail = 0;
        private string input;
        private Storyboard myStoryboard;

        public queueArray()
        {
            InitializeComponent();
        }

        //dequeue button
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (head == tail)
            {
                errorLabel.Content = "队列空";
            }
            else if (head > tail)
            {
                String labelName = "label" + tail.ToString();
                String ellipseName;
                Object label = this.GetType().GetField(labelName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                ((Label)label).Content = "";
                tail++;
                tailLabel.Content = tail;



                ((Ellipse)tailellipse).Stroke = new SolidColorBrush(Colors.Red);
                DoubleAnimation myDoubleAnimation = new DoubleAnimation();
                myDoubleAnimation.From = 0.0;
                myDoubleAnimation.To = 1.0;
                myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));
                myDoubleAnimation.AutoReverse = true;
                myStoryboard = new Storyboard();
                myStoryboard.Children.Add(myDoubleAnimation);
                Storyboard.SetTargetName(myDoubleAnimation, tailellipse.Name);
                Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Ellipse.OpacityProperty));
                myStoryboard.Begin(this);
                DoubleAnimation myDoubleAnimation2 = new DoubleAnimation();
                myDoubleAnimation.From = 0.0;
                myDoubleAnimation.To = 1.0;
                myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));
                myDoubleAnimation.AutoReverse = true;
                //myStoryboard = new Storyboard();
                myStoryboard.Children.Add(myDoubleAnimation);
                ellipseName = "ellipse" + (tail - 1).ToString();
                Object ellipsePop = this.GetType().GetField(ellipseName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                ((Ellipse)ellipsePop).Stroke = new SolidColorBrush(Colors.Red);
                Storyboard.SetTargetName(myDoubleAnimation, ellipseName);
                Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Ellipse.OpacityProperty));
                myStoryboard.Begin(this);
            }

        }

        //enqueue button
        private void button_Click(object sender, RoutedEventArgs e)
        {
            input = inputBox.Text;
            if (input.Length != 0)
            {
                String labelName = "label" + head.ToString();
                Object label = this.GetType().GetField(labelName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                ((Label)label).Content = input;
                headLabel.Content = head;
                // label.Content = input;
                inputBox.Clear();
                head++;

                DoubleAnimation myDoubleAnimation = new DoubleAnimation();
                myDoubleAnimation.From = 0.0;
                myDoubleAnimation.To = 1.0;
                myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));
                myDoubleAnimation.AutoReverse = true;
                myStoryboard = new Storyboard();
                myStoryboard.Children.Add(myDoubleAnimation);
                Storyboard.SetTargetName(myDoubleAnimation, headEllipse.Name);
                Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Ellipse.OpacityProperty));
                myStoryboard.Begin(this);
                DoubleAnimation myDoubleAnimation2 = new DoubleAnimation();
                myDoubleAnimation.From = 0.0;
                myDoubleAnimation.To = 1.0;
                myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));
                myDoubleAnimation.AutoReverse = true;
                //myStoryboard = new Storyboard();
                myStoryboard.Children.Add(myDoubleAnimation);
                String ellipseName = "ellipse" + (head - 1).ToString();
                Storyboard.SetTargetName(myDoubleAnimation, ellipseName);
                Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Ellipse.OpacityProperty));
                myStoryboard.Begin(this);
            }

        }

        //clear button
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            for (int i = head; i < tail; i++)
            {
                String labelName = "label" + i.ToString();
                Object label = this.GetType().GetField(labelName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                ((Label)label).Content = "";
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

