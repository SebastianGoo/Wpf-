using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadTreelistViewTest
{
    public class Department
    {
        public string Name { get; set; }
        public List<Department> SubDepartments { get; set; } = new List<Department>();

        public Department(string name)
        {
            this.Name = name;
        }

        public void AddSubDepartment(Department department)
        {
            SubDepartments.Add(department);
        }
    }

}
