using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using Telerik.Windows.Media.Imaging;

namespace ImageLoadTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point origin; // 记录拖拽开始时的鼠标位置
        private Point start; 
        public MainWindow()
        {
            InitializeComponent(); 
            //ImageEditor.ScaleFactorChanged-= RadImageEditor_ScaleFactorChanged;
            LoadSampleImage(this.ImageEditor, "超时.png");
            //  ImageEditor.ScaleFactorChanged += RadImageEditor_ScaleFactorChanged;
            ImageEditor.IsHitTestVisible=true;
            ImageEditor.Focusable = true;
            ImageEditor.Focus();
        }

        private void ImageEditor_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
            if (Keyboard.Modifiers != ModifierKeys.Control)
            {
                return; // 如果没有按下Ctrl键，则不执行任何操作
            }

            var image = sender as Image;
            if (image == null) return;
            Point position = e.GetPosition(image);
            if (position.X < 0 || position.Y < 0 || position.X > image.ActualWidth || position.Y > image.ActualHeight)
            {
                return; // 如果鼠标不在图片区域内，也不执行任何操作
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private static string SampleImageFolder = "SampleImages/";

        public static void LoadSampleImage(RadImageEditor imageEditor, string image)
        {
            using (Stream stream = Application.GetResourceStream(GetResourceUri(SampleImageFolder + image)).Stream)
            {
                imageEditor.Image = new Telerik.Windows.Media.Imaging.RadBitmap(stream);
                imageEditor.ApplyTemplate();
                imageEditor.ScaleFactor = 0;
            }
        }
        public static Uri GetResourceUri(string resource)
        {
            AssemblyName assemblyName = new AssemblyName(typeof(MainWindow).Assembly.FullName);
            string resourcePath = "/" + assemblyName.Name + ";component/" + resource;
            Uri resourceUri = new Uri(resourcePath, UriKind.Relative);

            return resourceUri;
        }

        private void RadImageEditor_ScaleFactorChanged(object sender, EventArgs e)
        {
            //获取缩放比例
            var scale = this.ImageEditor.ScaleFactor;
            ////获取RadBitmap`对象
            //var bitmap = this.ImageEditor.Image;
            ////获取原始图片的宽度和高度
            //var width = bitmap.Width;
            //var height = bitmap.Height;
            ////计算缩放后的宽度和高度

            //var newWidth = width * scale;
            //var newHeight = height * scale;
            ////设置新的宽度和高度
            //this.ImageEditor.Width = newWidth;
            //this.ImageEditor.Height = newHeight;
            //this.ImageEditor.ScaleFactor = scale;
            //this.ImageEditor.ApplyTemplate();
            
            double a=this.ImageEditor.Width;
            double b = this.ImageEditor.Height;

        }

        private void ImageEditor_MouseWheel_1(object sender, MouseWheelEventArgs e)
        {
            if (Keyboard.Modifiers != ModifierKeys.Control)
            {
                return; // 如果没有按下Ctrl键，则不执行任何操作
            }

            var image = e.OriginalSource as Image;
            if (image == null) return;
            Point position = e.GetPosition(image);
            if (position.X < 0 || position.Y < 0 || position.X > image.ActualWidth || position.Y > image.ActualHeight)
            {
                return; // 如果鼠标不在图片区域内，也不执行任何操作
            }
        }
          
        private void ImageEditor_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ImageEditor.IsMouseCaptured) return;
            ImageEditor.CaptureMouse();

            start = e.GetPosition(border);
            origin.X = ImageEditor.RenderTransform.Value.OffsetX;
            origin.Y = ImageEditor.RenderTransform.Value.OffsetY;

        }

        private void ImageEditor_MouseMove(object sender, MouseEventArgs e)
        {
            if (!ImageEditor.IsMouseCaptured) return;
            Point p = e.MouseDevice.GetPosition(border);

            Matrix m = ImageEditor.RenderTransform.Value;
            m.OffsetX = origin.X + (p.X - start.X);
            m.OffsetY = origin.Y + (p.Y - start.Y);

            ImageEditor.RenderTransform = new MatrixTransform(m);
        }



        private void ImageEditor_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}