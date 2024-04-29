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

namespace ImageLoadTest
{
    /// <summary>
    /// Image.xaml 的交互逻辑
    /// </summary>
    public partial class ImageTest : Window
    {
        private DateTime lastUpdate = DateTime.Now;

        private Point origin; // 记录拖拽开始时的鼠标位置
        private Point start;
        public ImageTest()
        {
            InitializeComponent();
        }

        private void myImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (myImage.IsMouseCaptured) return;
            myImage.CaptureMouse();

            start = e.GetPosition(myImage);
            origin.X = myImage.RenderTransform.Value.OffsetX;
            origin.Y = myImage.RenderTransform.Value.OffsetY;

        }

        private void myImage_MouseMove(object sender, MouseEventArgs e)
        {
              
        }

        private void myImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is Image image)
            {
                image.ReleaseMouseCapture(); // 停止捕获鼠标
            }
        }
    }
}
