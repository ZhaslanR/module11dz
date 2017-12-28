using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module11dz
{
    class Program
    {
        private static void Swap<T>(ref T first, ref T second)
        {
            T temporary = first;
            first = second;
            second = temporary;
        }
        private static void ParseNumber(out int number)
        {
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Clear();
                Console.Write("Ошибка! Введите корректное число: ");
            }
        }

        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            int numberOfEmployees;
            Console.Write("Введите количество сотрудников: ");
            ParseNumber(out numberOfEmployees);
            for (int i = 0; i < numberOfEmployees; i++)
            {
                Console.Clear();
                Employee employee = new Employee();

                Console.Write("Введите фамилию сотрудника: ");
                employee.LastName = Console.ReadLine();

                Console.Write("Введите имя сотрудника: ");
                employee.Name = Console.ReadLine();

                Console.Write("Введите возраст сотрудника: ");
                int age;
                ParseNumber(out age);
                employee.Age = age;

                Console.Write("Введите запрлату сотрудника: ");
                int salary;
                ParseNumber(out salary);
                employee.Salary = salary;

                int year, month, day;


                Console.Write("Введите год принятия на работу:");
                ParseNumber(out year);

                Console.Write("Введите месяц принятия на работу:");
                ParseNumber(out month);

                Console.Write("Введите день принятия на работу:");
                ParseNumber(out day);

                employee.Date = new DateTime((int)year, (int)month, (int)day);

                const int VACANCIES = 3;
                for (int j = 0; j < VACANCIES; j++)
                {
                    Console.WriteLine("{0}.{1}", j, (Position)j);
                }
                int vacancy;
                Console.Write("Выберите вакансию: ");
                ParseNumber(out vacancy);
                employee.VacancyOfEmployee = (Position)vacancy;

                employees.Add(employee);
            }


            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }

            const int MY_AVERAGE = 20_000;

            int clerksSalaryAverage = 0;
            int countOfClerks = 0;

            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].VacancyOfEmployee == Position.Clerk)
                {
                    clerksSalaryAverage += employees[i].Salary;
                    countOfClerks++;
                }
            }
            if (clerksSalaryAverage != 0) clerksSalaryAverage /= (int)countOfClerks;
            if (clerksSalaryAverage == 0)
            {
                clerksSalaryAverage = MY_AVERAGE;
            }

            List<Employee> majors = new List<Employee>();

            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].VacancyOfEmployee == Position.Manager)
                {
                    majors.Add(employees[i]);
                }
            }

            for (int i = 0; i < majors.Count; i++)
            {
                for (int j = 0; j < majors.Count - 1; j++)
                {
                    for (int k = 0; k < majors[k].LastName.Length && k < majors[k + 1].LastName.Length; k++)
                    {
                        if (majors[i].LastName[k] == majors[j + 1].LastName[k]) continue;
                        if (majors[i].LastName[k] > majors[j + 1].LastName[k])
                        {
                            Employee first = majors[j];
                            Employee second = majors[j + 1];
                            Swap(ref first, ref second);
                        }
                        break;
                    }
                }
            }

            foreach (var major in majors) Console.WriteLine(major);
            Employee boss = new Employee();

            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].VacancyOfEmployee == Position.Director)
                {
                    boss = employees[i];
                    break;
                }
            }
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i] != boss && employees[i].Date > boss.Date) Console.WriteLine(employees[i]);
            }

            Console.ReadLine();
        }
    }
}
