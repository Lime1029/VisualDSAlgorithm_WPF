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
        int numOfBlocks = 0;
        const int MAXBLOCKS = 6;
        MovingBlock[] blocks = new MovingBlock[MAXBLOCKS];
        
        Label label3 = new Label();//pushing/poping value的显示
        Label label4 = new Label();//push不能超过6个数，警告消息的显示
        
       
        public StackL()
        {
            InitializeComponent();
            
            label3.Margin = new Thickness(40, 53, 0, 0);
            label4.Margin = new Thickness(40, 70, 0, 0);
            canvas.Children.Add(label3);
            canvas.Children.Add(label4);
            
        }

        
        private void Click_Push(object sender, RoutedEventArgs e)
        {
            input = textInput.Text;
            

            if (input.Length != 0)
            {
                numOfBlocks += 1;

                if (numOfBlocks >= 7)
                {
                    label4.Content = "你输入超过了6个数！";
                    label4.FontSize = 20;
                    label4.Foreground = new SolidColorBrush(Colors.Red);
                    label4.FontWeight = FontWeights.Bold;
                    label4.Margin = new Thickness(200, 200, 0, 0);
                    numOfBlocks--;
                    return;
                }
                label4.Content = "(push最多6个数)";
                
                blocks[numOfBlocks - 1] = new MovingBlock();
                
                label3.Content = "Pushing Value: ";
                
                textInput.Clear();
                textInput.IsEnabled = false;
                button1.IsEnabled = false;
                button2.IsEnabled = false;
                button3.IsEnabled = false;
                

                blocks[numOfBlocks-1].movingNumber.Content = input;
                blocks[numOfBlocks - 1].movingNumber.Margin = new Thickness(140, 53, 0, 0);
                canvas.Children.Add(blocks[numOfBlocks-1].movingNumber);

                blocks[numOfBlocks-1].dataArea.Margin = new Thickness(243, 110, 0, 0);
                blocks[numOfBlocks - 1].dataLeft = blocks[numOfBlocks - 1].dataArea.Margin.Left;
                blocks[numOfBlocks - 1].dataTop = blocks[numOfBlocks - 1].dataArea.Margin.Top;
                canvas.Children.Add(blocks[numOfBlocks-1].dataArea);

                blocks[numOfBlocks-1].pointerArea.Margin = new Thickness(blocks[numOfBlocks - 1].dataArea.Margin.Left + blocks[numOfBlocks-1].dataArea.Width, blocks[numOfBlocks - 1].dataArea.Margin.Top, 0, 0);
                blocks[numOfBlocks - 1].pointerLeft = blocks[numOfBlocks - 1].dataArea.Margin.Left + blocks[numOfBlocks - 1].dataArea.Width;
                blocks[numOfBlocks - 1].pointerTop = blocks[numOfBlocks - 1].dataArea.Margin.Top;
                canvas.Children.Add(blocks[numOfBlocks-1].pointerArea);

                blocks[numOfBlocks-1].arrow.X1 = label2.Margin.Left + label2.Width / 2;
                blocks[numOfBlocks-1].arrow.Y1 = label2.Margin.Top + label2.Height / 2;
                blocks[numOfBlocks-1].arrow.X2 = blocks[numOfBlocks-1].dataArea.Margin.Left;
                blocks[numOfBlocks-1].arrow.Y2 = blocks[numOfBlocks-1].dataArea.Margin.Top + blocks[numOfBlocks-1].dataArea.Height / 2;
                canvas.Children.Add(blocks[numOfBlocks-1].arrow);

                //创建DispatcherTimer对象
                System.Windows.Threading.DispatcherTimer tmr1 = new System.Windows.Threading.DispatcherTimer();
                //设置间隔时间
                tmr1.Interval = TimeSpan.FromSeconds(0.01);
                //绑定函数
                tmr1.Tick += new EventHandler(Tmr1_Tick);
                tmr1.Start();//启动计时器
                
                
            }
            
        }

        void Tmr1_Tick(object sender, EventArgs e)
        {
            
            
            if (blocks[numOfBlocks - 1].tnumber.Y > 50)
            {
                
                blocks[numOfBlocks-1].tnumber.X -= 10;
                blocks[numOfBlocks-1].tnumber.Y += 15;

                blocks[numOfBlocks-1].tdata.X -= 10;
                blocks[numOfBlocks-1].tdata.Y += 15;

                blocks[numOfBlocks-1].tpointer.X -= 10;
                blocks[numOfBlocks-1].tpointer.Y += 15;

                blocks[numOfBlocks-1].pointerLeft -= 10;
                blocks[numOfBlocks-1].pointerTop += 15;

                blocks[numOfBlocks-1].dataLeft -= 10;
                blocks[numOfBlocks-1].dataTop += 15;

                
                blocks[numOfBlocks-1].arrow.X2 -= 10;
                blocks[numOfBlocks - 1].arrow.Y2 += 15;


                if (blocks[numOfBlocks-1].tnumber.X < 10)
                {
                    (sender as System.Windows.Threading.DispatcherTimer).Stop();
                    //label4.Content = "";
                    textInput.IsEnabled = true;
                    button1.IsEnabled = true;
                    button2.IsEnabled = true;
                    button3.IsEnabled = true;
                }

            }
            else
            {
                
                blocks[numOfBlocks-1].tnumber.X += 10;
                blocks[numOfBlocks-1].tnumber.Y += 5;
            }

            if (numOfBlocks > 1)
            {
                for (int i = 0; i < numOfBlocks - 1; i++)
                {
                    blocks[i].tdata.X += 5;
                    blocks[i].tpointer.X += 5;
                    blocks[i].tnumber.X += 5;

                    blocks[i].dataLeft += 5;
                    blocks[i].pointerLeft += 5;
                    
                    blocks[i].arrow.X1 = blocks[i+1].pointerLeft + blocks[i + 1].pointerArea.Width;
                    blocks[i].arrow.Y1 = blocks[i+1].pointerTop + blocks[i + 1].pointerArea.Height / 2;
                    blocks[i].arrow.X2 = blocks[i].dataLeft;
                    blocks[i].arrow.Y2 = blocks[i].dataTop + blocks[i].dataArea.Height / 2;
                }
            }

        }

        private void Click_Pop(object sender, RoutedEventArgs e)
        {
            textInput.Clear();
            textInput.IsEnabled = false;
            button1.IsEnabled = false;
            button2.IsEnabled = false;
            button3.IsEnabled = false;

            canvas.Children.Remove(blocks[numOfBlocks - 1].dataArea);
            canvas.Children.Remove(blocks[numOfBlocks - 1].pointerArea);
            canvas.Children.Remove(blocks[numOfBlocks - 1].arrow);

            label3.Content = "Poping Value:";
            label4.Content = "";
            System.Windows.Threading.DispatcherTimer tmr2 = new System.Windows.Threading.DispatcherTimer();
            tmr2.Interval = TimeSpan.FromSeconds(0.01);
            tmr2.Tick += new EventHandler(Tmr2_Tick);
            tmr2.Start();

            
        }

        private void Tmr2_Tick(object sender, EventArgs e)
        {
            if (numOfBlocks > 1)
            {
                for (int i = 0; i < numOfBlocks - 1; i++)
                {
                    blocks[i].tdata.X -= 5;
                    blocks[i].tpointer.X -= 5;
                    blocks[i].tnumber.X -= 5;

                    blocks[i].dataLeft -= 5;
                    blocks[i].pointerLeft -= 5;

                    if (i == numOfBlocks - 2 )
                    {
                        blocks[i].arrow.X1 = label2.Margin.Left + label2.Width / 2;
                        blocks[i].arrow.Y1 = label2.Margin.Top + label2.Height / 2;

                    }
                    else
                    {
                        blocks[i].arrow.X1 = blocks[i + 1].pointerLeft + blocks[i + 1].pointerArea.Width;
                        blocks[i].arrow.Y1 = blocks[i + 1].pointerTop + (blocks[i + 1].pointerArea.Height / 2);
                        
                    }
                    blocks[i].arrow.X2 = blocks[i].dataLeft;
                    blocks[i].arrow.Y2 = blocks[i].dataTop + (blocks[i].dataArea.Height / 2);
                }

            }

            if (blocks[numOfBlocks-1].tnumber.Y > 0)
            {
                blocks[numOfBlocks - 1].tnumber.Y -= 10;
            }
            else
            {
                label3.Content = "Poping Value: " + blocks[numOfBlocks - 1].movingNumber.Content;
                canvas.Children.Remove(blocks[numOfBlocks - 1].movingNumber);
                blocks[numOfBlocks - 1] = null;
                numOfBlocks--;
                (sender as System.Windows.Threading.DispatcherTimer).Stop();

                textInput.IsEnabled = true;
                button1.IsEnabled = true;
                button2.IsEnabled = true;
                button3.IsEnabled = true;
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
            label3.Content = "";label4.Content = "";
            textInput.Clear();
        }
    }
}
