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

namespace 加载页
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeHardwareAsync();
        }
        private async Task InitializeHardwareAsync()
        {
            string[] hardwareComponents = { "Component 1", "Component 2", "Component 3" };
            for (int i = 0; i < hardwareComponents.Length; i++)
            {
                UpdateStatus(hardwareComponents[i], (i + 1) * 100.0 / hardwareComponents.Length);
                await Task.Delay(1000); // 模拟耗时的初始化过程
            }
            Close(); // 初始化完成后关闭界面
        }

        private void UpdateStatus(string component, double progress)
        {
            Dispatcher.Invoke(() =>
            {
                statusText.Text = $"Initializing {component}...";
                progressBar.Value = progress;
            });
        }
    }
}