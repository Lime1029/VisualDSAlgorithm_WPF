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
    /// ComparingSort.xaml 的交互逻辑
    /// </summary>
    public partial class ComparingSort : Window
    {
        const int NUMOFBLOCKS = 10;
        const int INTERVAL = 30;
        const double DOWN = 150;
        DancingBlock[] blocks = new DancingBlock[NUMOFBLOCKS];
        DancingBlock tempBlock = new DancingBlock();

        int[] array = new int[NUMOFBLOCKS];

        public ComparingSort()
        {
            InitializeComponent();
        }

        public void RandomizeBlocks()
        {
            for (int i = 0; i < NUMOFBLOCKS; i++)
            {
                blocks[i] = new DancingBlock();
                blocks[i].lnumber.Margin = new Thickness(80 + (INTERVAL * i), 200, 0, 0);
                blocks[i].rectangle.Margin = new Thickness(80 + (INTERVAL * i), 200 - blocks[i].rectangle.Height, 0, 0);
                background.Children.Add(blocks[i].lnumber);
                background.Children.Add(blocks[i].rectangle);
                array[i] = blocks[i].number;
            }
        }

        public void ClearHistory()
        {
            if (blocks[0] != null)
            {
                for (int i = 0; i < NUMOFBLOCKS; i++)
                {
                    background.Children.Remove(blocks[i].rectangle);
                    background.Children.Remove(blocks[i].lnumber);
                    blocks[i] = null;
                }
            }
        }

        private void Wait(double pauseTime)
        {
            var t = DateTime.Now.AddMilliseconds(pauseTime);
            while (DateTime.Now < t)
                DispatcherHelper.DoEvents();
        }
        
        
        private void Button_Click_Insertion_Sort(object sender, RoutedEventArgs e)
        {
            ClearHistory();
            RandomizeBlocks();
            Wait(500);

            int i, j, guard;
            for (i = 1; i < NUMOFBLOCKS; i++)
            {
                guard = array[i];

                tempBlock = blocks[i];
                tempBlock.trec.Y += DOWN;
                tempBlock.tlabel.Y += DOWN;
                tempBlock.rectangle.Fill = Brushes.Orange;

                j = i - 1;
                while (j >= 0 && array[j] > guard)
                {
                    array[j + 1] = array[j];
                    
                    blocks[j].trec.X += 30;
                    blocks[j].tlabel.X += 30;
                    
                    blocks[j + 1] = blocks[j];

                    j--;
                    Wait(500);
                }
                
                array[j + 1] = guard;

                tempBlock.trec.X -= (i - j - 1) * INTERVAL;
                tempBlock.tlabel.X -= (i - j - 1) * INTERVAL;
                tempBlock.trec.Y -= DOWN;
                tempBlock.tlabel.Y -= DOWN;
                tempBlock.rectangle.Fill = Brushes.Purple;

                blocks[j + 1] = tempBlock;
                Wait(500);
            }
        }
        

        private void Button1_Click_Selection_Sort(object sender, RoutedEventArgs e)
        {
            ClearHistory();
            RandomizeBlocks();
            Wait(500);

            int temp = 0;
            for (int i = 0; i < NUMOFBLOCKS - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < NUMOFBLOCKS; j++)
                {
                    if (array[minIndex] > array[j])
                    {
                        minIndex = j;
                    }

                }
                temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;

                tempBlock = blocks[i];
                tempBlock.tlabel.Y += DOWN;
                tempBlock.trec.Y += DOWN;
                tempBlock.rectangle.Fill = Brushes.Orange;
                blocks[minIndex].rectangle.Fill = Brushes.Orange;
                Wait(500);

                blocks[minIndex].trec.X += (i - minIndex) * INTERVAL;
                blocks[minIndex].tlabel.X += (i - minIndex) * INTERVAL;
                Wait(500);

                tempBlock.trec.X += (minIndex - i) * INTERVAL;
                tempBlock.tlabel.X += (minIndex - i) * INTERVAL;
                tempBlock.tlabel.Y -= DOWN;
                tempBlock.trec.Y -= DOWN;
                tempBlock.rectangle.Fill = Brushes.Purple;
                blocks[minIndex].rectangle.Fill = Brushes.Purple;

                blocks[i] = blocks[minIndex];
                blocks[minIndex] = tempBlock;
                Wait(500);
            }
        }
        

        private void Button2_Click_Bubble_Sort(object sender, RoutedEventArgs e)
        {
            ClearHistory();
            RandomizeBlocks();
            Wait(500);

            int temp = 0;
            for (int i = 0; i < NUMOFBLOCKS - 1; i++)
            {
                for (int j = 0; j < NUMOFBLOCKS - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;

                        tempBlock = blocks[j];
                        tempBlock.tlabel.Y += DOWN;
                        tempBlock.trec.Y += DOWN;
                        tempBlock.rectangle.Fill = Brushes.Orange;
                        Wait(500);

                        blocks[j + 1].trec.X -= INTERVAL;
                        blocks[j + 1].tlabel.X -= INTERVAL;
                        Wait(500);

                        tempBlock.trec.X += INTERVAL;
                        tempBlock.tlabel.X += INTERVAL;
                        tempBlock.tlabel.Y -= DOWN;
                        tempBlock.trec.Y -= DOWN;
                        tempBlock.rectangle.Fill = Brushes.Purple;

                        blocks[j] = blocks[j + 1];
                        blocks[j + 1] = tempBlock;
                        Wait(500);
                    }
                }
            }
        }
        

        private void Button3_Click_Quick_Sort(object sender, RoutedEventArgs e)
        {
            ClearHistory();
            RandomizeBlocks();
            Wait(500);

            QuickSort(array, 0, array.Length - 1);
        }

        private void QuickSort(int[] arr, int low, int high)
        {
            if (low >= high) return;//这里很重要，否则会出现栈溢出
            int pivotLoc = Partition(arr, low, high);
            QuickSort(arr, low, pivotLoc - 1);
            QuickSort(arr, pivotLoc + 1, high);
        }

        private int Partition(int[] arr, int low, int high)
        {
            int temp = arr[low];

            tempBlock = blocks[low];
            tempBlock.tlabel.Y += DOWN;
            tempBlock.trec.Y += DOWN;
            tempBlock.rectangle.Fill = Brushes.Orange;
            int tempBlockIndex = low;
            while (low < high)
            {
                while (low < high && temp <= arr[high])
                {
                    high--;
                }
                arr[low] = arr[high];

                blocks[high].rectangle.Fill = Brushes.Orange;
                Wait(500);

                blocks[high].trec.X -= (high - low) * INTERVAL;
                blocks[high].tlabel.X -= (high - low) * INTERVAL;
                blocks[high].rectangle.Fill = Brushes.Purple;
                Wait(500);

                blocks[low] = blocks[high];


                while (low < high && temp >= arr[low])
                {
                    low++;
                }
                arr[high] = arr[low];

                blocks[low].rectangle.Fill = Brushes.Orange;
                Wait(500);

                blocks[low].trec.X += (high - low) * INTERVAL;
                blocks[low].tlabel.X += (high - low) * INTERVAL;
                blocks[low].rectangle.Fill = Brushes.Purple;
                Wait(500);

                blocks[high] = blocks[low];
            }
            arr[low] = temp;

            tempBlock.trec.X += (low - tempBlockIndex) * INTERVAL;
            tempBlock.tlabel.X += (low - tempBlockIndex) * INTERVAL;
            tempBlock.tlabel.Y -= DOWN;
            tempBlock.trec.Y -= DOWN;
            tempBlock.rectangle.Fill = Brushes.Purple;
            blocks[high] = tempBlock;
            return low;
        }

        
        private void Button4_Click_Merge_Sort(object sender, RoutedEventArgs e)
        {
            ClearHistory();
            RandomizeBlocks();
            Wait(500);
            MergeSort(array, 0, array.Length - 1);
        }
        
        private void Merge(int[] arr, int low, int mid, int high)
        {
            int[] mergeArr = new int[high - low + 1];

            DancingBlock[] mergeBlocks = new DancingBlock[high - low + 1];

            int left = low;
            int right = mid + 1;
            int mergeArrayIndex = 0;
            int mergeBlockIndex = 0;

            while (left <= mid && right <= high)
            {
                if (arr[left] <= arr[right])
                {

                    blocks[left].rectangle.Fill = Brushes.Orange;
                    blocks[right].rectangle.Fill = Brushes.Orange;
                    Wait(500);
                    mergeArr[mergeArrayIndex++] = arr[left];

                    mergeBlocks[mergeBlockIndex] = blocks[left];
                    mergeBlocks[mergeBlockIndex].lnumber.Margin = new Thickness(80 + (INTERVAL * mergeBlockIndex), 200 + DOWN, 0, 0);
                    mergeBlocks[mergeBlockIndex].rectangle.Margin = new Thickness(80 + (INTERVAL * mergeBlockIndex), 200 + DOWN - mergeBlocks[mergeBlockIndex].rectangle.Height, 0, 0);
                   
                    blocks[left].rectangle.Fill = Brushes.Purple;
                    blocks[right].rectangle.Fill = Brushes.Purple;
                    left++;mergeBlockIndex++;
                    
                }
                else
                {

                    blocks[left].rectangle.Fill = Brushes.Orange;
                    blocks[right].rectangle.Fill = Brushes.Orange;
                    Wait(500);
                    mergeArr[mergeArrayIndex++] = arr[right];

                    mergeBlocks[mergeBlockIndex] = blocks[right];
                    mergeBlocks[mergeBlockIndex].lnumber.Margin = new Thickness(80 + (INTERVAL * mergeBlockIndex), 200 + DOWN, 0, 0);
                    mergeBlocks[mergeBlockIndex].rectangle.Margin = new Thickness(80 + (INTERVAL * mergeBlockIndex), 200 + DOWN - mergeBlocks[mergeBlockIndex].rectangle.Height, 0, 0);
                    
                    blocks[left].rectangle.Fill = Brushes.Purple;
                    blocks[right].rectangle.Fill = Brushes.Purple;
                    right++;mergeBlockIndex++;
                    
                }
            }
            //Wait(500);

            while (left <= mid)
            {
                mergeArr[mergeArrayIndex++] = arr[left];
                mergeBlocks[mergeBlockIndex] = blocks[left];
                mergeBlocks[mergeBlockIndex].lnumber.Margin = new Thickness(80 + (INTERVAL * mergeBlockIndex), 200 + DOWN, 0, 0);
                mergeBlocks[mergeBlockIndex].rectangle.Margin = new Thickness(80 + (INTERVAL * mergeBlockIndex), 200 + DOWN - mergeBlocks[mergeBlockIndex].rectangle.Height, 0, 0);
                
                mergeBlockIndex++;left++;
            }
            while (right <= high)
            {
                mergeArr[mergeArrayIndex++] = arr[right];
                mergeBlocks[mergeBlockIndex] = blocks[right];
                mergeBlocks[mergeBlockIndex].lnumber.Margin = new Thickness(80 + (INTERVAL * mergeBlockIndex), 200 + DOWN, 0, 0);
                mergeBlocks[mergeBlockIndex].rectangle.Margin = new Thickness(80 + (INTERVAL * mergeBlockIndex), 200 + DOWN - mergeBlocks[mergeBlockIndex].rectangle.Height, 0, 0);
                
                mergeBlockIndex++; right++;
            }

            mergeArrayIndex = 0;
            mergeBlockIndex = 0;

            while (low <= high)
            {
                arr[low] = mergeArr[mergeArrayIndex++];
                blocks[low] = mergeBlocks[mergeBlockIndex++];
                Wait(500);
                blocks[low].lnumber.Margin = new Thickness(80 + (INTERVAL * low), 200, 0, 0);
                blocks[low].rectangle.Margin = new Thickness(80 + (INTERVAL * low), 200 - blocks[low].rectangle.Height, 0, 0);
                low++;
            }
        }

        private void MergeSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;
                MergeSort(arr, low, mid);
                MergeSort(arr, mid + 1, high);
                Merge(arr, low, mid, high);
            }
        }


        private void Button5_Click_Shell_Sort(object sender, RoutedEventArgs e)
        {
            ClearHistory();
            RandomizeBlocks();
            Wait(500);

            for (int h = array.Length / 2; h > 0; h = h / 2)
            {
                for (int i = h; i < array.Length; i++)
                {
                    if (array[i] < array[i - h])
                    {
                        for (int j = 0; j < i; j += h)
                        {
                            if (array[i] < array[j])
                            {
                                int temp = array[j];
                                array[j] = array[i];
                                array[i] = temp;

                                tempBlock = blocks[j];
                                tempBlock.tlabel.Y += DOWN;
                                tempBlock.trec.Y += DOWN;
                                tempBlock.rectangle.Fill = Brushes.Orange;

                                blocks[i].tlabel.Y += DOWN;
                                blocks[i].trec.Y += DOWN;
                                blocks[i].rectangle.Fill = Brushes.Orange;
                                Wait(500);

                                blocks[i].trec.X -= (i - j) * INTERVAL;
                                blocks[i].tlabel.X -= (i - j) * INTERVAL;
                                blocks[i].tlabel.Y -= DOWN;
                                blocks[i].trec.Y -= DOWN;
                                blocks[i].rectangle.Fill = Brushes.Purple;
                                
                                tempBlock.tlabel.X += (i - j) * INTERVAL;
                                tempBlock.trec.X += (i - j) * INTERVAL;
                                tempBlock.tlabel.Y -= DOWN;
                                tempBlock.trec.Y -= DOWN;
                                tempBlock.rectangle.Fill = Brushes.Purple;
                                
                                blocks[j] = blocks[i];
                                blocks[i] = tempBlock;
                                Wait(500);
                            }
                        }
                    }
                }
            }
        }

    }
}
