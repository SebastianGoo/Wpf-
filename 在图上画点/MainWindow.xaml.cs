using System.IO;
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

namespace 在图上画点
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            imageView.Source = new BitmapImage(new Uri("C:\\Users\\13989\\Desktop\\超时.png"));

        }
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // 获取鼠标点击的坐标
            Point position = e.GetPosition(imageView);

            // 创建标记点（例如红色圆点）
            Ellipse ellipse = new Ellipse
            {
                Width = 5,
                Height = 5,
                Fill = Brushes.Red
            };

            // 设置标记点的位置
            Canvas.SetLeft(ellipse, position.X - ellipse.Width / 2);
            Canvas.SetTop(ellipse, position.Y - ellipse.Height/2);


            // 将标记点添加到Canvas上
            canvas.Children.Add(ellipse);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var renderTargetBitmap = new RenderTargetBitmap(
                (int)canvas.ActualWidth,
                (int)canvas.ActualHeight,
                96d,  // dpiX，根据需要调整
                96d,  // dpiY，根据需要调整
                PixelFormats.Pbgra32);//保存的pixelformats 

            renderTargetBitmap.Render(canvas);

            var pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));

            using (FileStream fileStream = new FileStream("MarkedImage.png", FileMode.Create))
            {
                pngEncoder.Save(fileStream);
            }

        }
    }
}