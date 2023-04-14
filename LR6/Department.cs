using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR6
{
    public class Department
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
        private int _numberOfEmployees = 0;
        public int numberOfEmployees
        {
            get
            {
                return _numberOfEmployees;
            }
            set
            {
                _numberOfEmployees = value;
            }
        }

        private Company company;
        public Company GetCompany()
        {
            return company;
        }
        public void setCompany(Company company)
        {
            this.company = company;
        }

        public List<Employee> employees = new List<Employee>();
        public List<Employee> getEmployee()
        {
            return employees;
        }
        public void addEmpoyee(Employee employee)
        {
            numberOfEmployees++;
            employees.Add(employee);
        }
        public void removeEmployee(Employee employee)
        {
            numberOfEmployees--;
            employees.Remove(employee);
        }
    }
}
