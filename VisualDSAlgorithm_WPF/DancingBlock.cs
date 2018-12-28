using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace VisualDSAlgorithm_WPF
{
    
    class DancingBlock 
    {
        public int heightUnit = 5;
        //public int left;
        //public Brush recFill = Brushes.Purple;

        public Rectangle rectangle = new Rectangle();
        public TranslateTransform trec = new TranslateTransform();
        public TranslateTransform tlabel = new TranslateTransform();
        public Label lnumber = new Label();
        //public double recHeight;
        public Random rm;
        public int number;
        //public int index;
        //public double labelWidth = 20;
        //public double labelHeight = 10;
        //public double recWidth;

        static int GetRandomSeed()//用于生成不重复的随机数
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        public DancingBlock()
        {
            rm = new Random(GetRandomSeed());
            number = rm.Next(1, 20);
            
            //lnumber.BorderBrush = Brushes.Black;
            //lnumber.BorderThickness = new Thickness(1);
            //lnumber.Width = 20;
            //lnumber.Height = 20;
            lnumber.Content = number.ToString();
            lnumber.RenderTransform = tlabel;
            //recHeight = number * heightUnit;
            //recWidth = 10;

            //rectangle.Stroke = Brushes.Black;
            rectangle.Fill = Brushes.Purple;
            rectangle.Height = number * heightUnit;
            rectangle.Width = 20;
            rectangle.RenderTransform = trec;
            
        }
        
    }
}
