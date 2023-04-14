using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR6
{
    internal class Program
    {
        static void Main(string[] args)
        {       
            fillData();
            while (true)
            {
                Console.WriteLine("Хотите осуществить поиск?");
                var userChoice = Console.ReadKey();
                if (userChoice.Key != ConsoleKey.Y) continue;

                Console.WriteLine("Способ поиска?\n1 - Без linq\n2 - C linq");
                var method = Console.ReadKey();

                switch (method.Key)
                {
                    case ConsoleKey.D1:
                        SimpleSearch();
                        break;
                    case ConsoleKey.D2:
                        LinqSearch();
                        break;
                    default: break;
                }
            }

        }
        static List<Company> companies = new List<Company>();
        static List<Department> departments = new List<Department>();
        static List<Employee> employees = new List<Employee>();
        static List<FulltimeEmployee> fulltimeEmployees = new List<FulltimeEmployee>();
        static List<ContractEmployee> contractEmployees = new List<ContractEmployee>();
        static Dictionary<int, string> classes;
        static void LinqSearch()
        {
            Console.WriteLine("По какому классу хотите осуществить поиск?");
            foreach (var cls in classes)
            {
                Console.WriteLine($"{cls.Key}  {cls.Value}");
            }
            var selectedClass = Console.ReadKey();

            Console.Write("Введите что вы хотите найти: ");
            var textForSearch = Console.ReadLine();
            switch (selectedClass.Key)
            {
                case ConsoleKey.D1:
                    var com = companies.Where(x => x.gettitle().ToLower().Contains(textForSearch.ToLower()));
                    foreach (var x in com) Console.WriteLine($"\tКомпания - {x.gettitle()}");

                    var dep = departments.Where(d => d.gettitle().ToLower().Contains(textForSearch.ToLower()));
                    foreach (var d in dep) Console.WriteLine($"\tОтдел - {d.gettitle()}");
                    break;
                case ConsoleKey.D2:
                    var deps = departments.Where(d => d.gettitle().ToLower().Contains(textForSearch.ToLower()));
                    foreach (var d in deps) Console.WriteLine($"\tОтдел - {d.gettitle()}");

                    var emp = employees.Where(e => e.getname().ToLower().Contains(textForSearch.ToLower()));
                    foreach (var e in emp) Console.WriteLine($"\tCотрудник - {e.getname()}");

                    break;
                case ConsoleKey.D3:
                    var emps = employees.Where(e => e.getname().ToLower().Contains(textForSearch.ToLower()));
                    foreach (var e in emps) Console.WriteLine($"\tФИО - {e.getname()}");

                    var job = employees.Where(e => e.getname().ToLower().Contains(textForSearch.ToLower()));
                    foreach (var e in emps) Console.WriteLine($"\tДолжность - {e.getpost()}");

                    var sal = employees.Where(e => e.getname().ToLower().Contains(textForSearch.ToLower()));
                    foreach (var e in emps) Console.WriteLine($"\tОклад - {e.getsalary()}");

                    var calcsal = employees.Where(e => e.getname().ToLower().Contains(textForSearch.ToLower()));
                    foreach (var e in emps) Console.WriteLine($"\tРассчитать зарплату - {e.getCalculateSalary()}");

                    break;
                case ConsoleKey.D4:
                    var prem = employees.Where(e => e.getname().ToLower().Contains(textForSearch.ToLower()));
                    foreach (var e in prem) Console.WriteLine($"\tПремия - {(e as FulltimeEmployee).Premium}");

                    var calcsals = employees.Where(e => e.getname().ToLower().Contains(textForSearch.ToLower()));
                    foreach (var e in calcsals) Console.WriteLine($"\tРассчитать зарплату - {e.getCalculateSalary()}");
                    
                    break;
                default:
                    Console.WriteLine("Не удалось найти.");
                    break;
                case ConsoleKey.D5:
                    var calcsalse = employees.Where(e => e.getname().ToLower().Contains(textForSearch.ToLower()));
                    foreach (var e in calcsalse) Console.WriteLine($"\tРассчитать зарплату - {e.getCalculateSalary()}");

                    break;

            }
        }

        static void SimpleSearch()
        {
            Console.WriteLine("По какому классу хотите осуществить поиск?");
            foreach (var cls in classes)
            {
                Console.WriteLine($"{cls.Key}  {cls.Value}");
            }
            var selectedClass = Console.ReadKey();

            Console.Write("Введите что вы хотите найти: ");
            var textForSearch = Console.ReadLine();
            var founded = false;
            switch (selectedClass.Key)
            {
                case ConsoleKey.D1:
                    foreach (var com in companies)
                    {
                        if (com.gettitle().ToLower().Contains(textForSearch.ToLower()))
                        {
                            Console.WriteLine($"\tКомпания - {com.gettitle()}");
                            foreach (var dep in com.departments)
                            {
                                Console.WriteLine($"\tОтдел - {dep.gettitle()}");
                            }
                            founded = true;
                        }
                    }
                    if (!founded) Console.WriteLine($"(!)Ничего не найдено");
                    break;
                case ConsoleKey.D2:
                    foreach (var dep in departments)
                    {
                        if (dep.gettitle().ToLower().Contains(textForSearch.ToLower()))
                        {
                            Console.WriteLine($"\tОтдел - {dep.gettitle()}");
                            foreach (var emp in dep.employees)
                            {
                                Console.WriteLine($"\tCотрудник - {emp.getname()}");
                            }
                            founded = true;
                        }

                    }
                    if (!founded) Console.WriteLine($"(!)Ничего не найдено");
                    break;
                case ConsoleKey.D3:
                    foreach (var emp in employees)
                    {
                        if (emp.getname().ToLower().Contains(textForSearch.ToLower()))
                        {
                            Console.WriteLine($"\tФИО - {emp.getname()}");
                            Console.WriteLine($"\tДолжность - {emp.getpost()}");
                            Console.WriteLine($"\tОклад - {emp.getsalary()}");
                            Console.WriteLine($"\tРассчитать зарплату - {emp.getCalculateSalary()}");
                            founded = true;
                        }

                    }
                    if (!founded) Console.WriteLine($"(!)Ничего не найдено");
                    break;
                case ConsoleKey.D4:
                    foreach (var full in employees)
                    {
                        if (full.getname().ToLower().Contains(textForSearch.ToLower()))
                        {
                            Console.WriteLine($"\tПремия - {(full as FulltimeEmployee).Premium}");
                            Console.WriteLine($"\tРассчитать зарплату - {full.getCalculateSalary()}");
                            founded = true;
                        }
                    }
                    if (!founded) Console.WriteLine($"(!)Ничего не найдено");
                    break;
                default:
                    Console.WriteLine("Не удалось найти.");
                    break;
                case ConsoleKey.D5:
                    foreach (var full in employees)
                    {
                        if (full.getname().ToLower().Contains(textForSearch.ToLower()))
                        {
                            Console.WriteLine($"\tРассчитать зарплату - {full.getCalculateSalary()}");
                            founded = true;
                        }
                    }
                    if (!founded) Console.WriteLine($"(!)Ничего не найдено");
                    break;

            }
        }

        static void fillData()
        {
            Company Apple = new Company();
            companies.Add(Apple);
            Apple.settitle("Apple");
            Company Amazon = new Company();
            companies.Add(Amazon);
            Amazon.settitle("Amazon");
            Company Netflix = new Company();
            companies.Add(Netflix);
            Netflix.settitle("Netflix");

            Department departmentApple1 = new Department();
            Department departmentApple2 = new Department();
            Department departmentAmazon1 = new Department();
            Department departmentAmazon2 = new Department();
            Department departmentNetflix1 = new Department();
            Department departmentNetflix2 = new Department();

            departments.Add(departmentApple1);
            departmentApple1.settitle("Applelemon");
            departments.Add(departmentApple2);
            departmentApple2.settitle("Applebanana");
            departments.Add(departmentAmazon1);
            departmentAmazon1.settitle("Amazonbook");
            departments.Add(departmentAmazon2);
            departmentAmazon2.settitle("Amazonnote");
            departments.Add(departmentNetflix1);
            departmentNetflix1.settitle("Film");
            departments.Add(departmentNetflix2);
            departmentNetflix2.settitle("Serial");

            Apple.addDepartment(departmentApple1);
            Apple.addDepartment(departmentApple2);
            Amazon.addDepartment(departmentAmazon1);
            Amazon.addDepartment(departmentAmazon2);
            Netflix.addDepartment(departmentNetflix1);
            Netflix.addDepartment(departmentNetflix2);
            
            departmentApple1.setCompany(Apple);
            departmentApple2.setCompany(Apple);
            departmentAmazon1.setCompany(Amazon);
            departmentAmazon2.setCompany(Amazon);
            departmentNetflix1.setCompany(Netflix);
            departmentNetflix2.setCompany(Netflix);

            Employee employee1 = new FulltimeEmployee();
            Employee employee3 = new FulltimeEmployee();
            Employee employee5 = new FulltimeEmployee();
            Employee employee7 = new FulltimeEmployee();
            Employee employee9 = new FulltimeEmployee();
            Employee employee11 = new FulltimeEmployee();

            Employee employee2 =new ContractEmployee();
            Employee employee4 = new ContractEmployee();
            Employee employee6 = new ContractEmployee();
            Employee employee8 = new ContractEmployee();
            Employee employee10 = new ContractEmployee();
            Employee employee12 = new ContractEmployee();

            employees.Add(employee1);
            employees.Add(employee3);
            employees.Add(employee5);
            employees.Add(employee7);
            employees.Add(employee9);
            employees.Add(employee11);

            employees.Add(employee2);
            employees.Add(employee4);
            employees.Add(employee6);
            employees.Add(employee8);
            employees.Add(employee10);
            employees.Add(employee12);

            employee1.setname("Майкл Джордан");
            employee2.setname("Дженифер Лопес");
            employee3.setname("Гарри Поттер");
            employee4.setname("Лионель Месси");
            employee5.setname("Степан Владимиров");
            employee6.setname("Иван Иванов");
            employee7.setname("Роза Красных");
            employee8.setname("Полина Ястребова");
            employee9.setname("Антуан Гризманн");
            employee10.setname("Криштиану Роналду");
            employee11.setname("Златан Ибрагимович");
            employee12.setname("Гарри Магуайр");

            employee1.setpost("Разработчик ПО");
            employee2.setpost("Разработчик ПО");
            employee3.setpost("Разработчик ПО");
            employee4.setpost("Разработчик ПО");
            employee5.setpost("Разработчик ПО");
            employee6.setpost("Разработчик ПО");
            employee7.setpost("Разработчик ПО");
            employee8.setpost("Разработчик ПО");
            employee9.setpost("Разработчик ПО");
            employee10.setpost("Разработчик ПО");
            employee11.setpost("Разработчик ПО");
            employee12.setpost("Разработчик ПО");


            departmentApple1.addEmpoyee(employee1);
            departmentApple1.addEmpoyee(employee2);
            departmentApple2.addEmpoyee(employee3);
            departmentApple2.addEmpoyee(employee4);
            departmentAmazon1.addEmpoyee(employee5);
            departmentAmazon1.addEmpoyee(employee6);
            departmentAmazon2.addEmpoyee(employee7);
            departmentAmazon2.addEmpoyee(employee8);
            departmentNetflix1.addEmpoyee(employee9);
            departmentNetflix1.addEmpoyee(employee10);
            departmentNetflix2.addEmpoyee(employee11);
            departmentNetflix2.addEmpoyee(employee12);

            employee1.setDepartment(departmentApple1);
            employee2.setDepartment(departmentApple1);
            employee3.setDepartment(departmentApple2);
            employee4.setDepartment(departmentApple2);
            employee5.setDepartment(departmentAmazon1);
            employee6.setDepartment(departmentAmazon1);
            employee7.setDepartment(departmentAmazon2);
            employee8.setDepartment(departmentAmazon2);
            employee9.setDepartment(departmentNetflix1);
            employee10.setDepartment(departmentNetflix1);
            employee11.setDepartment(departmentNetflix2);
            employee12.setDepartment(departmentNetflix2);

            
            //Расчет ЗП
            employee1.getCalculateSalary();
            employee2.getCalculateSalary();
            employee3.getCalculateSalary();
            employee4.getCalculateSalary();
            employee5.getCalculateSalary();
            employee6.getCalculateSalary();
            employee7.getCalculateSalary();
            employee8.getCalculateSalary();
            employee9.getCalculateSalary();
            employee10.getCalculateSalary();
            employee11.getCalculateSalary();
            employee12.getCalculateSalary();
          
            Console.WriteLine("Зарплата всех сотрудников");
            (employee1 as FulltimeEmployee).Premium = 10000;
            (employee3 as FulltimeEmployee).Premium = 10000;
            (employee5 as FulltimeEmployee).Premium = 10000;
            (employee7 as FulltimeEmployee).Premium = 10000;
            (employee9 as FulltimeEmployee).Premium = 10000;
            (employee11 as FulltimeEmployee).Premium = 10000;
            employee1.salary = 40000;
            try
            {
                employee1.getsalary();
                employee3.getsalary();
                employee5.getsalary();
                employee7.getsalary();
                employee9.getsalary();
                employee11.getsalary();
            }
            catch (Exception)
            {
                Console.WriteLine($"Невозможно создать сотрудника – указан отрицательный оклад");
            }
            employee2.salary = 90000;
            employee3.salary = 90000;
            employee4.salary = 90000;
            employee5.salary = 90000;
            employee6.salary = 90000;
            employee7.salary = 90000;
            employee8.salary = 90000;
            employee9.salary = 90000;
            employee10.salary = 90000;
            employee11.salary = 90000;
            employee12.salary = 90000;
          
            classes = new Dictionary<int, string>();
            classes.Add(1, "Компания");
            classes.Add(2, "Отдел");
            classes.Add(3, "Cотрудник");
            classes.Add(4, "Штатный сотрудник");
            classes.Add(5, "Сотрудник по контракту");
        }
    }
}

