using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RadTreelistViewTest.Converters
{
    public class FolderFileIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isFolder = (bool)value;
            // 根据您的项目结构调整路径
            return isFolder ? "pack://application:,,,/RadTreelistViewTest;component/Images/file_folder.png" : "pack://application:,,,/RadTreelistViewTest;component/Images/file.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
