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

namespace VisualDSAlgorithm_WPF
{
    /// <summary>
    /// RadixSort.xaml 的交互逻辑
    /// </summary>
    public partial class RadixSort : Window
    {
        private int[] sortArray = new int[20];
        static int i = 0;

        public RadixSort()
        {
            InitializeComponent();
        }

        /*基数排序内容*/
        private int getMaxDigit()
        {
            int digit = 1;
            int base1 = 10;    //计算的基准
            for (int j = 0; j < sortArray.Length; j++)
            {
                while (sortArray[j] >= base1)
                {
                    ++digit;
                    base1 = base1 * 10;
                }
            }
            digitlabel.Content = digit.ToString();
            wait();
            //返回最大数有多少位
            return digit;
        }


        //LSD 从低位开始
        private void LSDSort()
        {
            int n = sortArray.Length;
            int base1 = 1;
            int digit = getMaxDigit();
            while (digit>0)
            {
                digit--;
                int[] count = new int[10];  //统计对应位数相同的数的个数
                int[] start = new int[10];  //统计对应位数的第一个数出现的位置
                int[] temp = new int[n];
                for (int j = 0; j < count.Length; j++)
                {
                    count[j] = 0;
                    start[j] = 0;
                    Object label = FindName("index" + j.ToString());
                    ((Label)label).Content = "0";
                }
                
                for (int j = 0; j <n ; j++)
                {
                    setLabelColor(j);
                    int index = sortArray[j] / base1 % 10;
                    count[index]++;
                    setEllipseColor(index);
                    Object label = FindName("index"+index.ToString());
                    ((Label)label).Content = (count[index]).ToString();
                    wait();
                    temp[j] = 0;

                    cancelEllipseColor(index);
                    cancelLabelColor(j);
                }

                for (int j = 1; j < count.Length; j++)
                {
                    start[j] = count[j - 1] + start[j - 1];
                    Object label = FindName("index" + j.ToString());
                    ((Label)label).Content = (start[j]).ToString();
                }

                //从原数组中排序
                for(int j = 0; j < n; j++)
                {
                    setLabelColor(j);
                    int index = sortArray[j] / base1 % 10;
                    setEllipseColor(index);
                    temp[start[index]] = sortArray[j];

                    Object labeltemp = FindName("labeltemp" + (start[index]).ToString());
                    ((Label)labeltemp).Content = (sortArray[j]).ToString();

                    start[index]++;
                    Object label = FindName("index" + index.ToString());
                    ((Label)label).Content = (start[index]).ToString();
                    cancelLabelColor(j);
                    cancelEllipseColor(index);
                }

                wait();
                for (int i = 0; i < sortArray.Length; i++)
                {
                    String labelName = "label" + i.ToString();
                    Object label = FindName(labelName);
                    ((Label)label).Content = "";
                }
                wait();

                //将temp数组中的内容复制到原数组中
                for (int j = 0; j < n; j++)
                {
                    sortArray[j] = temp[j];
                    tempPut(j,temp);
                }
                base1 = base1 * 10;
            }            
        }

        private void tempPut(int i,int[] temp)
        {
            String labeltempName = "labeltemp" + i.ToString();
            Object labeltemp = FindName(labeltempName);
            ((Label)labeltemp).BorderThickness = new Thickness(3);
            ((Label)labeltemp).BorderBrush = new SolidColorBrush(Colors.Orange);
            wait();
            int t = temp[i];
            String labelName = "label" + i.ToString();
            Object label = FindName(labelName);
            ((Label)label).Content = t.ToString();
            ((Label)labeltemp).Content = "";
            wait();
            ((Label)labeltemp).BorderThickness = new Thickness(1);
            ((Label)labeltemp).BorderBrush = new SolidColorBrush(Colors.Black);
        }


        private void setLabelColor(int i)
        {
            String labelName = "label" + i.ToString();
            Object label = FindName(labelName);
            ((Label)label).BorderThickness = new Thickness(3);
            ((Label)label).BorderBrush = new SolidColorBrush(Colors.Red);
            wait();
        }

        private void setEllipseColor(int i)
        {
            String ellipseName = "indexEllipse" + i.ToString();
            Object ellipse = FindName(ellipseName);
            ((Ellipse)ellipse).StrokeThickness = 3;
            ((Ellipse)ellipse).Stroke = new SolidColorBrush(Colors.Blue);
            ((Ellipse)ellipse).Opacity = 1.0;
            wait();
        }

        private void cancelEllipseColor(int i)
        {
            String ellipseName = "indexEllipse" + i.ToString();
            Object ellipse = FindName(ellipseName);
            ((Ellipse)ellipse).Opacity = 0;
            /*((Ellipse)ellipse).StrokeThickness = 1;
            ((Ellipse)ellipse).Stroke = new SolidColorBrush(Colors.Black);*/
            wait();
        }

        private void cancelLabelColor(int i)
        {
            String labelName = "label" + i.ToString();
            Object label = FindName(labelName);
            ((Label)label).BorderThickness = new Thickness(1);
            ((Label)label).BorderBrush = new SolidColorBrush(Colors.Black);
            wait();
        }



        private void wait()
        {
            //程序暂停执行
            var t = DateTime.Now.AddMilliseconds(50);
            while (DateTime.Now < t)
                DispatcherHelper.DoEvents();
        }

        private void sortButton_Click(object sender, RoutedEventArgs e)
        {
            LSDSort();
            //int digit=getMaxDigit();
            infolabel.Content = "success";
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            /*if (i >= 15)
            {
                infolabel.Foreground = new SolidColorBrush(Colors.Red);
                return;
            }*/
            //获取用户输入
            int content = int.Parse(addTextBox.Text);
            addLabel(content);

        }

        private void addLabel(int content)
        {
            sortArray[i] = content;
            Label label = new Label();
            //label.Name = "label" + i.ToString();
            label.Content = content;
            label.BorderBrush = new SolidColorBrush(Colors.Black);
            label.BorderThickness = new Thickness(1);
            label.HorizontalContentAlignment = HorizontalAlignment.Center;
            label.VerticalContentAlignment = VerticalAlignment.Center;
            label.Width = 40;
            label.Height = 40;
            contentStack.Children.Add(label);
            contentStack.RegisterName("label" + i.ToString(), label);

            Label labeltemp = new Label();
            labeltemp.BorderBrush = new SolidColorBrush(Colors.Black);
            labeltemp.BorderThickness = new Thickness(1);
            labeltemp.HorizontalContentAlignment = HorizontalAlignment.Center;
            labeltemp.VerticalContentAlignment = VerticalAlignment.Center;
            labeltemp.Width = 40;
            labeltemp.Height = 40;
            tempStack.Children.Add(labeltemp);
            tempStack.RegisterName("labeltemp" + i.ToString(), labeltemp);

            i++;
        }

        private void autoButton_Click(object sender, RoutedEventArgs e)
        {
            int[] array = { 433,794,80,144,124,764,11,26,819,488,702,680,102,533,557,200,762,322,570,52 };
            for (int i = 0; i < array.Length; i++)
            {
                addLabel(array[i]);
            }
        }

        private void addMidContainer()
        {

        }
    }
}
