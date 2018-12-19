using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace VisualDSAlgorithm_WPF
{
    class MovingBlock
    {
        public Label pointerArea = new Label();
        public Label dataArea = new Label();
        public Label movingNumber = new Label();

        /*public double pointerWidth = 20;
        public double dataWidth = 30;
        public double pointerHeight = 20;
        public double dataHeight = 20;*/
        public double pointerLeft;
        public double pointerTop;
        public double dataLeft;
        public double dataTop;

        public TranslateTransform tdata = new TranslateTransform();
        public TranslateTransform tpointer = new TranslateTransform();
        public TranslateTransform tnumber = new TranslateTransform();

        public Arrow arrow = new Arrow();

        public MovingBlock()
        {
            pointerArea.BorderBrush = Brushes.Black;
            pointerArea.BorderThickness = new System.Windows.Thickness(1);
            pointerArea.RenderTransform = tpointer;
            pointerArea.Width = 20;
            //pointerArea.Margin = new System.Windows.Thickness(230, 60, 0, 0);
            pointerArea.Height = 20;

            dataArea.BorderBrush = Brushes.Black;
            dataArea.BorderThickness = new System.Windows.Thickness(1);
            //dataArea.Margin = new System.Windows.Thickness(200, 60, 0, 0);
            dataArea.Width = 30;
            dataArea.Height = 20;
            dataArea.RenderTransform = tdata;

            //movingNumber.Margin = new System.Windows.Thickness(140, 53, 0, 0);
            movingNumber.RenderTransform = tnumber;

            arrow.Stroke = new SolidColorBrush(Colors.Black);
            arrow.HeadWidth = 8;
            arrow.HeadHeight = 4;
            //arrow.X2 = dataArea.Margin.Left;
            //arrow.Y2 = dataArea.Margin.Top + dataHeight / 2;
            
        }

        

    }
}
