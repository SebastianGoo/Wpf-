using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RadTreeviewBinding
{
    public partial class MainViewModel:ObservableValidator
    {
        public ObservableCollection<TreeNode> InspectionNodes { get; private set; }

        public MainViewModel()
        {
            // 初始化 Inspection 节点集合
            InspectionNodes = new ObservableCollection<TreeNode>
        {
            new TreeNode("IA") { Children = { new TreeNode("A"), new TreeNode("B"), new TreeNode("C"), new TreeNode("D") } }
        };
        }

        [RelayCommand]
        public void AddInspectionItem()
        {
            var inputDialog = new InputDialog();
            if (inputDialog.ShowDialog() == true)
            {
                InspectionNodes.Add(new TreeNode(inputDialog.ResponseText));
            }
        }
        [RelayCommand]
        private void Navigate(string viewName)
        {
            MessageBox.Show(viewName);
        }


    }
}
