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
    /// heap.xaml 的交互逻辑
    /// </summary>
   public partial class heap : Window
    {
        public heap()
        {
            InitializeComponent();
        }

        //Label label;







        static int i = 0; //记录当前加了多少个label了



        int row = 1; //行



        int column = 1;//列



        int canvaswidth = 800;







        //container



        StackPanel stackpanel;



        Canvas canvas;







        Boolean hasContainer = false;







        private void createContainer()



        {



            stackpanel = new StackPanel();



            /*<StackPanel Name="contentStack" HorizontalAlignment="Left" Height="40" Margin="52,75,0,0" VerticalAlignment="Top" Width="736" Orientation="Horizontal"/>


 
             */



            stackpanel.HorizontalAlignment = HorizontalAlignment.Left;



            stackpanel.Margin = new Thickness(52, 75, 0, 0);



            stackpanel.Height = 40;



            stackpanel.VerticalAlignment = VerticalAlignment.Top;



            stackpanel.Width = 736;



            stackpanel.Orientation = Orientation.Horizontal;



            all.RegisterName("contentStack", stackpanel);







            /*


 
             * <Canvas Name="container" HorizontalAlignment="Left" Height="585" Margin="52,150,0,-66" VerticalAlignment="Top" Width="800">


 
            <Grid Height="100" Canvas.Left="591" Canvas.Top="217" Width="100"/>


 
        </Canvas>


 
             */



            canvas = new Canvas();



            canvas.HorizontalAlignment = HorizontalAlignment.Left;



            canvas.Height = 585;



            canvas.Margin = new Thickness(52, 150, 0, -66);



            canvas.VerticalAlignment = VerticalAlignment.Top;



            canvas.Width = 800;



            all.RegisterName("container", canvas);



        }











        //用来存放用户输入的内容的数组



        int[] heapArray = new int[15];



        private void button_Click(object sender, RoutedEventArgs e)



        {



            /*if (!hasContainer)


 
            {


 
                hasContainer = true;


 
                createContainer();


 
            }*/



            //向堆中添加内容的按钮



            if (i >= 15)



            {



                infolabel.Foreground = new SolidColorBrush(Colors.Red);



                return;



            }



            //添加label



            int content = int.Parse(addTextBox.Text);



            //将用户输入存放入实际的堆中



            heapArray[i] = content;



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











            //添加树节点



            /*


 
             * 第i行 共有2^(i-1)个节点


 
             * 节点将canvas分为2^(i-1)+1个部分


 
             * 


 
             */



            int nodenum = (int)Math.Pow(2.0, row - 1);



            double margin = (canvaswidth) / (nodenum + 1);



            Grid nodeC = new Grid();



            double x = margin * column;



            double y = row * 100;



            //左 上 右 下



            nodeC.Margin = new Thickness(x - 25, y - 25, 0, 0);



            nodeC.Width = 50;



            nodeC.Height = 50;



            //container.Children.Add(nodeC);



            Ellipse ellipse = new Ellipse();



            //ellipse.Name = "ellipse" + i.ToString();



            ellipse.StrokeThickness = 1;



            ellipse.Stroke = new SolidColorBrush(Colors.Black);



            ellipse.Width = 50;



            ellipse.Height = 50;



            TextBlock node = new TextBlock();



            node.Text = addTextBox.Text;



            node.VerticalAlignment = VerticalAlignment.Center;



            node.HorizontalAlignment = HorizontalAlignment.Center;



            nodeC.Children.Add(ellipse);



            //nodeC.RegisterName( "ellipse" + i.ToString(),ellipse);



            container.RegisterName("ellipse" + i.ToString(), ellipse);



            container.RegisterName("text" + i.ToString(), node);



            nodeC.Children.Add(node);



            container.Children.Add(nodeC);



            /*


 
             * arrow.Stroke = new SolidColorBrush(Colors.Black);


 
            arrow.HeadWidth = 8;


 
            arrow.HeadHeight = 4;


 
            //arrow.X2 = dataArea.Margin.Left;


 
            //arrow.Y2 = dataArea.Margin.Top + dataHeight / 2;


 
             */



            if (row != 1)



            {



                Arrow arrow = new Arrow();



                arrow.Stroke = new SolidColorBrush(Colors.Black);



                arrow.HeadWidth = 8;



                arrow.HeadHeight = 4;







                int pcolumn = (int)(column + 1) / 2;



                int prow = row - 1;



                arrow.X1 = (canvaswidth / (nodenum / 2 + 1)) * pcolumn;



                arrow.Y1 = prow * 100 + 25;



                arrow.X2 = x;



                arrow.Y2 = y - 25;



                container.Children.Add(arrow);



            }



            //添加箭头



            if (column == nodenum)



            {



                row++;



                column = 1;



            }



            else



            {



                column++;



            }



            i++;



        }







        private void heapSortButton_Click(object sender, RoutedEventArgs e)



        {



            //由于用户输入的内容是不确定的，所以当用户选择排序时转存到另一个数组



            int length = heapArray.Length;



            int[] heapT = new int[i];



            for (int index = 0; index < i; index++)



            {



                heapT[index] = heapArray[index];



            }



            heapSort(heapT);



        }







        private void heapAdjust(int[] array, int parent, int length)



        {



            int temp = array[parent];//父节点的值



            int child = 2 * parent + 1; //左孩子



            while (child < length)



            {



                Boolean flag = false; //用于标识是否选取了右节点



                Boolean flag2 = false;//用于标识child是否进行了加1



                // 如果有右孩子结点，并且右孩子结点的值大于左孩子结点，则选取右孩子结点



                setColor(child); //将左节点颜色加深



                if (child + 1 < length)



                {



                    setColor(child + 1);



                    flag = true;



                    if (array[child] < array[child + 1])



                    {



                        flag2 = true;



                        child++;



                        //flag = true;



                    }



                }







                //如果父结点的值已经大于孩子结点的值，则直接结束



                setColor(parent);//将父节点颜色加深



                cancelColor(parent);



                cancelColor(child);



                if (flag == true && flag2 == true)



                {



                    cancelColor(child - 1);



                }
                else if (flag == true && flag2 == false)



                {



                    cancelColor(child + 1);



                }



                if (temp >= array[child])



                {



                    break;



                }







                // 把孩子结点的值赋给父结点



                array[parent] = array[child];



                exchange(parent, child);



                //exchangetext(parent, child);



                // 选取孩子结点的左孩子结点,继续向下筛选



                parent = child;



                child = 2 * child + 1;



            }



            array[parent] = temp;



        }







        private void heapSort(int[] list)



        {



            for (int index = list.Length / 2; index >= 0; index--)



            {



                heapAdjust(list, index, list.Length);



            }



            for (int index = list.Length - 1; index > 0; index--)



            {



                // 最后一个元素和第一元素进行交换



                int temp = list[index];



                list[index] = list[0];



                list[0] = temp;



                //exchangetext(index, 0);



                exchange(index, 0);



                setSuccessColor(index);



                // 筛选 R[0] 结点，得到i-1个结点的堆



                heapAdjust(list, 0, index);



            }



            setSuccessColor(0);



            //infolabel.Content = list[0].ToString() + list[1].ToString() + list[2].ToString() + list[3].ToString() + list[4].ToString() + list[5].ToString() + list[6].ToString();



        }



        /*


 
         String labelName = "label" + index.ToString();


 
            Object label = this.GetType().GetField(labelName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);


 
            ((Label)label).BorderBrush = new SolidColorBrush(Colors.Black);


 
            ((Label)label).BorderThickness = new Thickness(1);


 
            Slabel.BorderBrush = new SolidColorBrush(Colors.Black);


 
            Slabel.BorderThickness = new Thickness(1);


 
            wait();


 
             */



        private void setColor(int i)



        {



            String ellipseName = "ellipse" + i.ToString();



            //Object ellipse = this.GetType().GetField(ellipseName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);



            Object ellipse = FindName(ellipseName);



            if (ellipse == null)



            {



                return;



            }



            ((Ellipse)ellipse).Stroke = new SolidColorBrush(Colors.Red);



            ((Ellipse)ellipse).StrokeThickness = 3;



            //同时修改label和圆形



            String labelName = "label" + i.ToString();



            Object label = FindName(labelName);



            ((Label)label).BorderThickness = new Thickness(3);



            ((Label)label).BorderBrush = new SolidColorBrush(Colors.Red);



            wait();



        }







        private void cancelColor(int i)



        {



            String ellipseName = "ellipse" + i.ToString();



            //Ellipse ellipse = (Ellipse)this.GetType().GetField(ellipseName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);



            Object ellipse = FindName(ellipseName);



            ((Ellipse)ellipse).StrokeThickness = 1;



            ((Ellipse)ellipse).Stroke = new SolidColorBrush(Colors.Black);







            String labelName = "label" + i.ToString();



            Object label = FindName(labelName);



            ((Label)label).BorderThickness = new Thickness(1);



            ((Label)label).BorderBrush = new SolidColorBrush(Colors.Black);







            wait();



        }







        private void setLabelColor(int i)



        {



            String labelName = "label" + i.ToString();



            Object label = FindName(labelName);



            ((Label)label).BorderThickness = new Thickness(3);



            ((Label)label).BorderBrush = new SolidColorBrush(Colors.Red);



            wait();



        }







        private void cancelLabelColor(int i)



        {







        }







        private void exchange(int i, int j)



        {



            wait();



            String labelNameI = "label" + i.ToString();



            String labelNameJ = "label" + j.ToString();



            //Label labelI =(Label) this.GetType().GetField(labelNameI, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);



            //Label labelJ =(Label) this.GetType().GetField(labelNameJ, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);



            Label labelI = (Label)FindName(labelNameI);



            Label labelJ = (Label)FindName(labelNameJ);



            string temp = labelI.Content + "";



            labelI.Content = labelJ.Content;



            labelJ.Content = temp;







            String textNameI = "text" + i.ToString();



            String textNameJ = "text" + j.ToString();



            //Label labelI =(Label) this.GetType().GetField(labelNameI, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);



            //Label labelJ =(Label) this.GetType().GetField(labelNameJ, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);



            TextBlock textI = (TextBlock)FindName(textNameI);



            TextBlock textJ = (TextBlock)FindName(textNameJ);



            labelI.Foreground = new SolidColorBrush(Colors.Blue);



            labelJ.Foreground = new SolidColorBrush(Colors.Blue);



            textI.Foreground = new SolidColorBrush(Colors.Blue);



            textJ.Foreground = new SolidColorBrush(Colors.Blue);



            wait();



            string temp2 = textI.Text;



            textI.Text = textJ.Text;



            textJ.Text = temp2;



            wait();



            labelI.Foreground = new SolidColorBrush(Colors.Black);



            labelJ.Foreground = new SolidColorBrush(Colors.Black);



            textI.Foreground = new SolidColorBrush(Colors.Black);



            textJ.Foreground = new SolidColorBrush(Colors.Black);



        }







        private void exchangetext(int i, int j)



        {



            //目前这个函数是被废弃掉的，已经被合并到exchange里面



            wait();



            String textNameI = "text" + i.ToString();



            String textNameJ = "text" + j.ToString();



            //Label labelI =(Label) this.GetType().GetField(labelNameI, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);



            //Label labelJ =(Label) this.GetType().GetField(labelNameJ, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);



            TextBlock textI = (TextBlock)FindName(textNameI);



            TextBlock textJ = (TextBlock)FindName(textNameJ);







            string temp = textI.Text;



            textI.Text = textJ.Text;



            textJ.Text = temp;



            wait();



        }







        private void setSuccessColor(int i)



        {



            String ellipseName = "ellipse" + i.ToString();



            //Ellipse ellipse = (Ellipse)this.GetType().GetField(ellipseName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);



            Object ellipse = FindName(ellipseName);



            ((Ellipse)ellipse).StrokeThickness = 3;



            ((Ellipse)ellipse).Stroke = new SolidColorBrush(Colors.Orange);







            String labelName = "label" + i.ToString();



            Object label = FindName(labelName);



            ((Label)label).BorderThickness = new Thickness(3);



            ((Label)label).BorderBrush = new SolidColorBrush(Colors.Orange);



        }







        private void wait()



        {



            //程序暂停执行



            var t = DateTime.Now.AddMilliseconds(500);



            while (DateTime.Now < t)



                DispatcherHelper.DoEvents();



        }







        private void autobutton_Click(object sender, RoutedEventArgs e)



        {



            // createContainer();



            int[] auto = { 1, 3, 4, 5, 2, 6, 9 };



            for (int index = 0; index < auto.Length; index++)



            {



                if (i >= 15)



                {



                    infolabel.Foreground = new SolidColorBrush(Colors.Red);



                    return;



                }



                //添加label



                //int content = int.Parse(addTextBox.Text);



                int content = auto[index];



                //将用户输入存放入实际的堆中



                heapArray[i] = content;



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











                //添加树节点



                /*


 
                 * 第i行 共有2^(i-1)个节点


 
                 * 节点将canvas分为2^(i-1)+1个部分


 
                 * 


 
                 */



                int nodenum = (int)Math.Pow(2.0, row - 1);



                double margin = (canvaswidth) / (nodenum + 1);



                Grid nodeC = new Grid();



                double x = margin * column;



                double y = row * 100;
                //左 上 右 下
                nodeC.Margin = new Thickness(x - 25, y - 25, 0, 0);
                nodeC.Width = 50;
                nodeC.Height = 50;
                Ellipse ellipse = new Ellipse();
                ellipse.StrokeThickness = 1;
                ellipse.Stroke = new SolidColorBrush(Colors.Black);
                ellipse.Width = 50;
                ellipse.Height = 50;
                TextBlock node = new TextBlock();
                node.Text = content.ToString();
                node.VerticalAlignment = VerticalAlignment.Center;
                node.HorizontalAlignment = HorizontalAlignment.Center;
                nodeC.Children.Add(ellipse);
                container.RegisterName("ellipse" + i.ToString(), ellipse);
                container.RegisterName("text" + i.ToString(), node);
                nodeC.Children.Add(node);
                container.Children.Add(nodeC);
                /*
                 * arrow.Stroke = new SolidColorBrush(Colors.Black);
                arrow.HeadWidth = 8;
                arrow.HeadHeight = 4;
                //arrow.X2 = dataArea.Margin.Left;
                //arrow.Y2 = dataArea.Margin.Top + dataHeight / 2;
                 */
                if (row != 1)
                {
                    Arrow arrow = new Arrow();
                    arrow.Stroke = new SolidColorBrush(Colors.Black);
                    arrow.HeadWidth = 8;
                    arrow.HeadHeight = 4;
                    int pcolumn = (int)(column + 1) / 2;
                    int prow = row - 1;
                    arrow.X1 = (canvaswidth / (nodenum / 2 + 1)) * pcolumn;
                    arrow.Y1 = prow * 100 + 25;
                    arrow.X2 = x;
                    arrow.Y2 = y - 25;
                    container.Children.Add(arrow);
                }
                //添加箭头
                if (column == nodenum)
                {
                    row++;
                    column = 1;
                }
                else
                {
                    column++;
                }
                i++;
            }
        }
    }
}