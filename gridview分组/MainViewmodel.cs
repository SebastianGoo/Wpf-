using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gridview分组
{
    public class MainViewModel
    {
        public ObservableCollection<Product> Data { get; set; }

        public MainViewModel()
        {
            Data = new ObservableCollection<Product>
            {
                new Product { Name = "Apple", Category = "Fruit", Price = 1.2 },
                new Product { Name = "Banana", Category = "Fruit", Price = 0.8 },
                new Product { Name = "Carrot", Category = "Vegetable", Price = 0.5 },
                new Product { Name = "Broccoli", Category = "Vegetable", Price = 1.3 }
            };
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
    }
}
