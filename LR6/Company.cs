using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR6
{
    public class Company //объявление класса Company
    {
        public string title;
        public String gettitle()
        {
            return title;
        }
        public void settitle(String newtitle)
        {
            title = newtitle;
        }

        public List<Department> departments = new List<Department>();
        public List<Department> getDepartment()
        {
            return departments;
        }
        public void addDepartment(Department department)
        {
            departments.Add(department);
        }
        public void removeDepartment(Department department)
        {
            departments.Remove(department);
        }
        public List<Employee> Reference(string FIO)
        {
            List<Employee> Emps = new List<Employee>();
            foreach (Department d in departments)
            {
                foreach (Employee e in d.employees)
                {
                    if (e.getname() == FIO)
                    {
                        Emps.Add(e);
                    }
                }
            }
            return Emps;
        }
    }
}
