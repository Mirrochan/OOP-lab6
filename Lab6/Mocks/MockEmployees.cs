using Lab6.Models;
using Lab6.Interfaces;
using System;

namespace Lab6.Mocks
{
    public class MockEmployees : IEmployees
    {
        // Статичний список для збереження співробітників
        private static List<Employees> _employeeList = new List<Employees>
        {
            new Employees{Id=1,FirstName="Volodya",LastName="Toska", Email="qqq@gmail.com", DateTime="10/2003"},
            new Employees{Id=2, FirstName="Alex", LastName="Durov",Email="70jj",DateTime="7/2009"},
            new Employees{Id=3, FirstName="Ann", LastName="Smith",Email="Smithh_8", DateTime="12/2014"}
        };

        // Реалізація інтерфейсу IEmployees
        public IEnumerable<Employees> employees
        {
            get { return _employeeList; }
        }

        // Метод для додавання нового співробітника до списку
        public void AddEmployee(Employees newEmployee)
        {
            _employeeList.Add(newEmployee);
        }
    }
}
