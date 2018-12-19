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
    /// QueueL.xaml 的交互逻辑
    /// </summary>
    public partial class QueueL : Window
    {
        string input;
        int numOfBlocks = 0;
        const int MAXBLOCKS = 6;
        MovingBlock[] blocks = new MovingBlock[MAXBLOCKS];

        Label label4 = new Label();

        Arrow tailArrow = new Arrow();

        public QueueL()
        {
            InitializeComponent();

            label4.Margin = new Thickness(40, 55, 0, 0);
            canvas.Children.Add(label4);

            tailArrow.X1 = label3.Margin.Left + (label3.Width / 2);
            tailArrow.Y1 = label3.Margin.Top + (label3.Height / 2);
            tailArrow.HeadWidth = 8;
            tailArrow.HeadHeight = 4;
            canvas.Children.Add(tailArrow);
        }

        private void Click_Enqueue(object sender, RoutedEventArgs e)
        {
            input = textInput.Text;

            if (input.Length != 0)
            {
                numOfBlocks += 1;
                blocks[numOfBlocks - 1] = new MovingBlock();
                
                label4.Content = "Enqueuing Value: ";

                textInput.Clear();
                textInput.IsEnabled = false;

                blocks[numOfBlocks - 1].movingNumber.Content = input;
                blocks[numOfBlocks - 1].movingNumber.Margin = new Thickness(160, 55, 0, 0);
                canvas.Children.Add(blocks[numOfBlocks - 1].movingNumber);

                blocks[numOfBlocks - 1].dataArea.Margin = new Thickness(265, 113, 0, 0);
                blocks[numOfBlocks - 1].dataLeft = blocks[numOfBlocks - 1].dataArea.Margin.Left;
                blocks[numOfBlocks - 1].dataTop = blocks[numOfBlocks - 1].dataArea.Margin.Top;
                canvas.Children.Add(blocks[numOfBlocks - 1].dataArea);

                blocks[numOfBlocks - 1].pointerArea.Margin = new Thickness(blocks[numOfBlocks - 1].dataArea.Margin.Left + blocks[numOfBlocks - 1].dataArea.Width, blocks[numOfBlocks - 1].dataArea.Margin.Top, 0, 0);
                blocks[numOfBlocks - 1].pointerLeft = blocks[numOfBlocks - 1].dataArea.Margin.Left + blocks[numOfBlocks - 1].dataArea.Width;
                blocks[numOfBlocks - 1].pointerTop = blocks[numOfBlocks - 1].dataArea.Margin.Top;
                canvas.Children.Add(blocks[numOfBlocks - 1].pointerArea);

                //第一个block，head的指针指向它
                blocks[0].arrow.X1 = label2.Margin.Left + (label2.Width / 2);
                blocks[0].arrow.Y1 = label2.Margin.Top + (label2.Height / 2);
                
                if (numOfBlocks > 1)//X1,Y1默认为0，不指定会指向左上角
                {
                    blocks[numOfBlocks-1].arrow.X1 = blocks[numOfBlocks - 1 - 1].pointerLeft + blocks[numOfBlocks - 1 - 1].pointerArea.Width;
                    blocks[numOfBlocks - 1].arrow.Y1 = blocks[numOfBlocks - 1 - 1].pointerTop + (blocks[numOfBlocks - 1 - 1].pointerArea.Height / 2);
                }
                blocks[numOfBlocks - 1].arrow.X2 = blocks[numOfBlocks - 1].dataArea.Margin.Left;
                blocks[numOfBlocks - 1].arrow.Y2 = blocks[numOfBlocks - 1].dataArea.Margin.Top + (blocks[numOfBlocks - 1].dataArea.Height / 2);
                canvas.Children.Add(blocks[numOfBlocks - 1].arrow);

                //arrow from tail
                //tailArrow.X1 = label3.Margin.Left + (label3.Width / 2);
                //tailArrow.Y1 = label3.Margin.Top + (label3.Height / 2);
                tailArrow.X2 = blocks[numOfBlocks - 1].dataArea.Margin.Left + (blocks[numOfBlocks - 1].dataArea.Width / 2);
                tailArrow.Y2 = blocks[numOfBlocks - 1].dataArea.Margin.Top + blocks[numOfBlocks - 1].dataArea.Height;
                //tailArrow.HeadWidth = 8;
                //tailArrow.HeadHeight = 4;
                tailArrow.Stroke = new SolidColorBrush(Colors.Black);
                

                System.Windows.Threading.DispatcherTimer tmr1 = new System.Windows.Threading.DispatcherTimer();
                tmr1.Interval = TimeSpan.FromSeconds(0.01);
                tmr1.Tick += new EventHandler(Tmr1_Tick);
                tmr1.Start();
            }
        }

        private void Tmr1_Tick(object sender, EventArgs e)
        {
            //textInput.Text = blocks[numOfBlocks - 1].tnumber.X.ToString() + "," + blocks[numOfBlocks - 1].tnumber.Y.ToString() + "," + blocks[numOfBlocks - 1].tdata.X;
            
            if (blocks[numOfBlocks-1].tnumber.Y > 50)
            {
                blocks[numOfBlocks - 1].tdata.X -= (110-70*(numOfBlocks-1))/11.0;//dataArea's movement
                blocks[numOfBlocks - 1].tdata.Y += 15;

                blocks[numOfBlocks - 1].dataLeft -= (110 - 70 * (numOfBlocks - 1)) / 11.0;//change in data's Margin
                blocks[numOfBlocks - 1].dataTop += 15;

                blocks[numOfBlocks - 1].tpointer.X -= (110 - 70 * (numOfBlocks - 1)) / 11.0;//pointerArea's movement
                blocks[numOfBlocks - 1].tpointer.Y += 15;

                blocks[numOfBlocks - 1].pointerLeft -= (110 - 70 * (numOfBlocks - 1)) / 11.0;//change in pointer's Margin
                blocks[numOfBlocks - 1].pointerTop += 15;

                blocks[numOfBlocks - 1].tnumber.X -= (110 - 70 * (numOfBlocks - 1)) / 11.0;//movingNumber's movement
                blocks[numOfBlocks - 1].tnumber.Y += 15;

                blocks[numOfBlocks - 1].arrow.X2 -= (110 - 70 * (numOfBlocks - 1)) / 11.00;//arrow.X2 change
                blocks[numOfBlocks - 1].arrow.Y2 += 15;
                
                tailArrow.X2 = blocks[numOfBlocks - 1].dataLeft + (blocks[numOfBlocks - 1].dataArea.Width / 2);
                tailArrow.Y2 = blocks[numOfBlocks - 1].dataTop + blocks[numOfBlocks - 1].dataArea.Height;

                if (blocks[numOfBlocks-1].tnumber.Y > 220)//动画停止
                {
                    (sender as System.Windows.Threading.DispatcherTimer).Stop();
                    textInput.IsEnabled = true;
                    //label4.Content = "";
                }
               
            }
            else
            {
                blocks[numOfBlocks - 1].tnumber.X += 10;
                blocks[numOfBlocks - 1].tnumber.Y += 5;
                
            }
            

        }

        private void Click_Dequeue(object sender, RoutedEventArgs e)
        {
            label4.Content = "Dequeuing Value: ";

            System.Windows.Threading.DispatcherTimer tmr2 = new System.Windows.Threading.DispatcherTimer();
            tmr2.Interval = TimeSpan.FromSeconds(0.01);
            tmr2.Tick += new EventHandler(Tmr2_Tick);
            tmr2.Start();

            /*canvas.Children.Remove(blocks[0].dataArea);
            canvas.Children.Remove(blocks[0].pointerArea);
            canvas.Children.Remove(blocks[0].arrow);*/

        }

        private void Tmr2_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (blocks[0].tnumber.Y > 0)
            {
                blocks[0].tnumber.Y -= 10;
            }
            else
            {
                label4.Content = "Dequeuing Value: " + blocks[0].movingNumber.Content;
                canvas.Children.Remove(blocks[0].movingNumber);
                canvas.Children.Remove(blocks[0].dataArea);
                canvas.Children.Remove(blocks[0].pointerArea);
                canvas.Children.Remove(blocks[0].arrow);
                if (numOfBlocks > 1)
                {
                    blocks[1].arrow.X1 = label2.Margin.Left + (label2.Width / 2);
                    blocks[1].arrow.Y1 = label2.Margin.Top + (label2.Height / 2);
                    for (int i = 0; i < numOfBlocks-1; i++)
                    {
                        blocks[i+1].tnumber.X -= 70;
                        blocks[i+1].tdata.X -= 70;
                        blocks[i+1].tpointer.X -= 70;

                        blocks[i + 1].dataLeft -= 70;
                        blocks[i + 1].pointerLeft -= 70;
                        if (i > 0)//后来的block[0]的箭头的X1不动
                        {
                            blocks[i + 1].arrow.X1 -= 70;
                        }
                        blocks[i + 1].arrow.X2 -= 70;
                        blocks[i] = blocks[i + 1];
                    }
                }
                
                blocks[numOfBlocks-1] = null;
                numOfBlocks--;

                if (numOfBlocks == 0)//如果dequeue最后一个block，则隐藏tailArrow
                {
                    tailArrow.Stroke = new SolidColorBrush();
                }
                else
                {
                    tailArrow.X2 = blocks[numOfBlocks - 1].dataLeft + (blocks[numOfBlocks - 1].dataArea.Width / 2);
                    tailArrow.Y2 = blocks[numOfBlocks - 1].dataTop + blocks[numOfBlocks - 1].dataArea.Height;
                }
                
                (sender as System.Windows.Threading.DispatcherTimer).Stop();
            }


        }

        private void Click_Clear(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < numOfBlocks; i++)
            {
                canvas.Children.Remove(blocks[i].dataArea);
                canvas.Children.Remove(blocks[i].pointerArea);
                canvas.Children.Remove(blocks[i].movingNumber);
                canvas.Children.Remove(blocks[i].arrow);
                blocks[i] = null;
            }
            label4.Content = "";
            tailArrow.Stroke = new SolidColorBrush();
        }
    }
}
