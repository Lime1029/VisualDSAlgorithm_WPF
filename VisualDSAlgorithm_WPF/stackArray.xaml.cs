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
    /// stackArray.xaml 的交互逻辑
    /// </summary>
    public partial class stackArray : Window
    {
        public stackArray()
        {
            InitializeComponent();
        }

        private String input;  //输入获得的内容
        private static int index = 0;
        private Ellipse ell;
        private Label mLabel;
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private Storyboard myStoryboard;
        //push button
        private void button_Click(object sender, RoutedEventArgs e)
        {
            //input = int.Parse(inputBox.Text);
            Object ellipsePush;
            if (index < 20)
            {
                input = inputBox.Text;
                if (input.Length != 0)
                {
                    ellipse.Visibility = System.Windows.Visibility.Visible;
                    String labelName = "label" + index.ToString();
                    Object label = this.GetType().GetField(labelName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                    ((Label)label).Content = input;
                    waitLabel.Content = input;
                    // label.Content = input;
                    inputBox.Clear();

                    //动画效果
                    DoubleAnimation myDoubleAnimation = new DoubleAnimation();
                    myDoubleAnimation.From = 1.0;
                    myDoubleAnimation.To = 0.0;
                    myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));
                    myDoubleAnimation.AutoReverse = false;
                    myStoryboard = new Storyboard();
                    myStoryboard.Children.Add(myDoubleAnimation);
                    Storyboard.SetTargetName(myDoubleAnimation, ellipse.Name);
                    Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Ellipse.OpacityProperty));
                    myStoryboard.Begin(this);

                    DoubleAnimation myDoubleAnimation2 = new DoubleAnimation();
                    myDoubleAnimation.From = 0.0;
                    myDoubleAnimation.To = 1.0;
                    myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));
                    myDoubleAnimation.AutoReverse = true;
                    //myStoryboard = new Storyboard();
                    myStoryboard.Children.Add(myDoubleAnimation);
                    String ellipseName = "ellipse" + index.ToString();
                    ellipsePush = this.GetType().GetField(ellipseName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);

                    ellipse.Stroke = new SolidColorBrush(Colors.Blue);
                    ((Ellipse)ellipsePush).Stroke = new SolidColorBrush(Colors.Blue);
                    Storyboard.SetTargetName(myDoubleAnimation, ellipseName);
                    Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Ellipse.OpacityProperty));
                    myStoryboard.Begin(this);
                    index++;
                }
            }
            else
            {
                errorLabel.Content = "栈满，很抱歉，无法继续压栈";
            }

        }

        //pop button
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Object label;
            Object ellipsePop;
            Object Top;
            if (index == 0)
            {
                errorLabel.Content = "当前栈中无元素，不可出栈";
            }
            else
            {
                String labelName = "label" + (index - 1).ToString();
                String ellipseName = "ellipse" + (index - 1).ToString();
                String topName = "label" + (index - 2).ToString();
                label = this.GetType().GetField(labelName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                ellipsePop = this.GetType().GetField(ellipseName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                String poped = ((Label)label).Content.ToString();
                String top;
                if (index - 2 < 0)
                {
                    top = "null";
                }
                else
                {
                    Top = this.GetType().GetField(topName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                    top = ((Label)Top).Content.ToString();
                }
                waitLabel.Content = top;
                ((Label)label).Content = "";
                popedlabel.Content = poped;
                //动画效果
                ((Ellipse)ellipsePop).Stroke = new SolidColorBrush(Colors.Red);
                DoubleAnimation myDoubleAnimation = new DoubleAnimation();
                myDoubleAnimation.From = 0.0;
                myDoubleAnimation.To = 1.0;
                myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));
                myDoubleAnimation.AutoReverse = true;
                myStoryboard = new Storyboard();
                myStoryboard.Children.Add(myDoubleAnimation);
                Storyboard.SetTargetName(myDoubleAnimation, ellipsepop.Name);
                Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Ellipse.OpacityProperty));
                myStoryboard.Begin(this);
                DoubleAnimation myDoubleAnimation2 = new DoubleAnimation();
                myDoubleAnimation.From = 0.0;
                myDoubleAnimation.To = 1.0;
                myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.5));
                myDoubleAnimation.AutoReverse = true;
                //myStoryboard = new Storyboard();
                myStoryboard.Children.Add(myDoubleAnimation);
                //String ellipseName = "ellipse" + (index - 1).ToString();
                Storyboard.SetTargetName(myDoubleAnimation, ellipseName);
                Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Ellipse.OpacityProperty));
                myStoryboard.Begin(this);
                index--;
            }
        }

        //clear button
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < index; i++)
            {
                String labelName = "label" + i.ToString();
                Object label = this.GetType().GetField(labelName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                ((Label)label).Content = "";
            }
            index = 0;
            waitLabel.Content = "null";
        }
    }
}

