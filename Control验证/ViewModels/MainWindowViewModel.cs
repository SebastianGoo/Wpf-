using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control验证.ViewModels
{
  public partial  class MainWindowViewModel:ObservableValidator
    {
        public MainWindowViewModel()
        {
                ComboBoxItems = new ObservableCollection<string> { "Item 1", "Item 2", "Item 3" };
        }
        public ObservableCollection<string> ComboBoxItems { get; }

        [ObservableProperty]
        private string selectItem;

        // 可以添加命令处理 ComboBox 选择变更等逻辑
        [RelayCommand]
        private void DoSomethingWithSelectedItem()
        {
            // 用 selectedItem 做些事情
            string x = SelectItem;
        }
    }
}
