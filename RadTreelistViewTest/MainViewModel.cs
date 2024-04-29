using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls.DataVisualization.Map.BingRest;

namespace RadTreelistViewTest
{
   public partial class MainViewModel:ObservableValidator
    {
        public FileSystemItem RootFolder { get; set; }

        [ObservableProperty]
        public FileSystemItem selectedItem;
        private void InitializeFileSystem()
        {
            // 创建根目录
            RootFolder = new FileSystemItem { Name = "Root", Children = new ObservableCollection<FileSystemItem>() };

            // 添加一些文件夹和文件
            var folder1 = new FileSystemItem { Name = "Folder1", Children = new ObservableCollection<FileSystemItem>() };
            var file1 = new FileSystemItem { Name = "File1.txt", Size = 1234, FileType = "txt" };
            var file2 = new FileSystemItem { Name = "File2.jpg", Size = 2345, FileType = "jpg" };

            folder1.Children.Add(file1);
            folder1.Children.Add(file2);

            var folder2 = new FileSystemItem { Name = "Folder2", Children = new ObservableCollection<FileSystemItem>() };
            var subfolder1 = new FileSystemItem { Name = "SubFolder1", Children = new ObservableCollection<FileSystemItem>() };
            var subfile1 = new FileSystemItem { Name = "SubFile1.txt", Size = 3456, FileType = "txt" };

            subfolder1.Children.Add(subfile1);
            folder2.Children.Add(subfolder1);

            RootFolder.Children.Add(folder1);
            RootFolder.Children.Add(folder2);
        }
        // public ObservableCollection<Department> Departments { get; set; } = new ObservableCollection<Department>();

        public MainViewModel()
        {
            #region
            // 初始化部门数据
            //Department hr = new Department("Human Resources");
            //hr.AddSubDepartment(new Department("Recruitment"));
            //hr.AddSubDepartment(new Department("Employee Relations"));

            //Department it = new Department("Information Technology");
            //it.AddSubDepartment(new Department("Software Development"));
            ////it.AddSubDepartment(new Department("IT Support"));
            //Department itsupport=new Department("IT Support");
            //itsupport.AddSubDepartment(new Department("network"));
            //it.AddSubDepartment(itsupport);
            //Departments.Add(hr);
            //Departments.Add(it);
            #endregion
            //RootFolder = new RecipeFolder("Root");

            // 示例数据
            InitializeFileSystem();

        }

        [RelayCommand(CanExecute =nameof(CanExecuteAddItem))]
        void AddItem()
        {
            if (SelectedItem.IsFolder)
            {
                // 如果是文件夹，在该文件夹内添加新文件
                SelectedItem.Children.Add(new FileSystemItem { Name = "New File.txt", Size = 100, FileType = "txt" });
                //RootFolder.Children.Add(SelectedItem);
            }
            else
            {
                // 如果是文件，在同一级添加新文件
                var parentFolder = FindParent(RootFolder, SelectedItem);
                parentFolder?.Children.Add(new FileSystemItem { Name = "New File.txt", Size = 100, FileType = "txt" });
            }
        }

        private FileSystemItem FindParent(FileSystemItem root, FileSystemItem child)
        {
            // 遍历寻找父项
            foreach (var item in root.Children)
            {
                if (item == child)
                    return root;
                var found = FindParent(item, child);
                if (found != null)
                    return found;
            }
            return null;
        }

        private bool CanExecuteAddItem()
        {
            return SelectedItem != null;
        }
    }
}
