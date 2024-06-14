using Newtonsoft.Json.Linq;
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

namespace AlgoDynamicInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GenerateUIFromJson();

        }
        private void GenerateUIFromJson()
        {
            string json = @"
            {
                'Version': {
                    'AlgoVersion': 0.0,
                    'SoftwareVersionHigher': 0.0
                },
                'SentistivityPara': {
                    'DDO_H1': {
                        'type': 'Defect',
                        'value': 95,
                        'default': 100,
                        'min': 0,
                        'max': 100,
                        'defectid':1,
                        'planeid': 1,
                        'display_mode':1
                    },
                    'DDO_H1.LEC': {
                        'type': 'Defect',
                        'value': 95,
                        'default': 100,
                        'min': 0,
                        'max': 100,
                        'defectid':1,
                        'planeid': 1,
                        'display_mode':1
                    },
                    'DDO_H1.EDGE': {
                        'type': 'OPTION',
                        'value': 95,
                        'default': 100,
                        'min': 0,
                        'max': 100,
                        'defectid':1,
                        'planeid': 1,
                        'display_mode':1
                    },
                    'bSubpixel': {
                        'type': 'OPTION',
                        'value': 95,
                        'default': 100,
                        'min': 0,
                        'max': 100,
                        'defectid':1,
                        'planeid': 1,
                        'display_mode':1
                    }
                },
                'Alignpara': {
                    'DDO_H1': {
                        'type': 'Defect',
                        'value': 95,
                        'default': 100,
                        'min': 0,
                        'max': 100,
                        'defectid':1,
                        'planeid': 1,
                        'display_mode':1
                    },
                    'DDO_H1.LEC': {
                        'type': 'Defect',
                        'value': 95,
                        'default': 100,
                        'min': 0,
                        'max': 100,
                        'defectid':1,
                        'planeid': 1,
                        'display_mode':1
                    },
                    'DDO_H1.EDGE': {
                        'type': 'OPTION',
                        'value': 95,
                        'default': 100,
                        'min': 0,
                        'max': 100,
                        'defectid':1,
                        'planeid': 1,
                        'display_mode':1
                    },
                    'bSubpixel': {
                        'type': 'OPTION',
                        'value': 95,
                        'default': 100,
                        'min': 0,
                        'max': 100,
                        'defectid':1,
                        'planeid': 1,
                        'display_mode':1
                    }
                }
            }";

            JObject jsonObject = JObject.Parse(json);

            // 获取 SentistivityPara 节点
            JObject sensitivityPara = (JObject)jsonObject["SentistivityPara"];

            // 动态生成控件
            foreach (var item in sensitivityPara)
            {
                string name = item.Key;
                JObject properties = (JObject)item.Value;

                // 创建Label
                System.Windows.Controls.Label label = new System.Windows.Controls.Label();
                label.Content = name;

                // 根据属性动态创建控件
                FrameworkElement control = CreateControlFromProperties(properties);

                // 将控件添加到布局容器
                MainStackPanel.Children.Add(label);
                MainStackPanel.Children.Add(control);
            }
        }

        private FrameworkElement CreateControlFromProperties(JObject properties)
        {
            string type = properties["type"].ToString();
            int min = properties.ContainsKey("min") ? properties["min"].ToObject<int>() : 0;
            int max = properties.ContainsKey("max") ? properties["max"].ToObject<int>() : 100;
            int value = properties.ContainsKey("value") ? properties["value"].ToObject<int>() : 0;

            FrameworkElement control = null;

            if (type == "Defect")
            {
                RadNumericUpDown numericUpDown = new RadNumericUpDown();
                numericUpDown.Minimum = min;
                numericUpDown.Maximum = max;
                numericUpDown.Value = value;
                control = numericUpDown;
            }
            else if (type == "OPTION")
            {
                // 创建其他类型控件的逻辑
                // 例如使用RadComboBox来处理OPTION类型
                RadComboBox comboBox = new RadComboBox();
                StyleManager.SetTheme(comboBox, new Windows11Theme());
                comboBox.Items.Add("Option 1");
                comboBox.Items.Add("Option 2");
                comboBox.SelectedIndex = 0;
                control = comboBox;
            }

            return control;
        }
    }
}