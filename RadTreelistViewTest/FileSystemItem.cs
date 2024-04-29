using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadTreelistViewTest
{

    /// <summary>
    /// 数据库怎么设计
    /// </summary>
    public class FileSystemItem: ObservableObject
    {
        public string Name { get; set; }
        public long? Size { get; set; }  // 文件时不为 null
        public string FileType { get; set; }  // 文件时不为 null
        public ObservableCollection<FileSystemItem> Children { get; set; }  // 文件夹时不为 null
        public bool IsFolder => FileType==null;  // 通过是否有子项判断是否为文件夹

        public FileSystemItem()
        {
            Children = new ObservableCollection<FileSystemItem>();
        }
    }

}
