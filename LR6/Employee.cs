using LR6;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR6
{
    public abstract class Employee
    {
        public string name;
        public String getname()
        {
            return name;
        }
        public void setname(String newname)
        {
            name = newname;
        }


        public string post;
        public String getpost()
        {
            return post;
        }
        public void setpost(String newpost)
        {
            post = newpost;
        }


        public int salary;
        public int getsalary()
        {
            try
            {
                if (salary < 0)
                {
                    throw new OkladExсeption();
                }
            }
            catch (OkladExсeption)
            {
                throw new OkladExсeption();
            }
            return salary;
        }
        public void setsalary(int newsalary)
        {
            salary = newsalary;
        }


        private Department department;
        public Department GetDepartment()
        {
            return department;
        }
        public void setDepartment(Department department)
        {
            this.department = department;
        }
        public abstract int getCalculateSalary();
    }
    public class FulltimeEmployee : Employee
    {
        public int _Premium;
        public int Premium
        {
            get
                { return _Premium; }
            set
            {
                _Premium = value;   // устанавливаем новое значение свойства
            }
        }
        public override int getCalculateSalary()
        {
            try
            {
                if (_Premium < 0)
                {
                    throw new PremiaExсeption();
                }
                return _Premium + salary;
            }
            catch (PremiaExсeption)
            {
                Console.WriteLine("Премия меньше нуля.");
                return salary;
            }
        }

    }
    public class ContractEmployee : Employee
    {
        public override int getCalculateSalary()
        {

            return salary;
        }
    }

    public class PremiaExсeption : Exception
    {
        public PremiaExсeption() : base()
        {

        }
    }
    public class OkladExсeption : Exception
    {
        public OkladExсeption() : base()
        {

        }
    }
}
