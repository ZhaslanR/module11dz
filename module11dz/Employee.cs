using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module11dz
{
    public class Employee
    {
        public string LastName { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public DateTime Date { get; set; }
        public Position VacancyOfEmployee { get; set; }

        public Employee(string lastName = "Фамилия", string name = "Имя", int age = 20, int salary = 20_000, DateTime dateOfHiring = new DateTime(), Position vacancyOfEmployee = Position.Clerk)
        {
            LastName = lastName;
            Name = name;
            Age = age;
            Salary = salary;
            Date = dateOfHiring;
            VacancyOfEmployee = vacancyOfEmployee;
        }

        public override string ToString()
        {
            return string.Format("Фамилия: {0}\nИмя: {1}\nВозраст: {2}\nЗарплата: {3}\nДата нанятия: {4}:{5}:{6}\nДолжность: {7}\n", LastName, Name, Age, Salary, Date.Year, Date.Month, Date.Day, VacancyOfEmployee);
        }
    }
}
