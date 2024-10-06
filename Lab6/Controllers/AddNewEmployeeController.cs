using Lab6.Interfaces;
using Lab6.Mocks;
using Lab6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers
{
    public class AddNewEmployeeController : Controller
    {
        private readonly IEmployees _employeesService;

        public AddNewEmployeeController(IEmployees employeesService)
        {
            _employeesService = employeesService;
        }

        // Метод для відображення списку співробітників
        public IActionResult Index()
        {
            var employees = _employeesService.employees; // Отримуємо список співробітників
            return View(employees);
        }

        // Метод для відображення форми додавання співробітника (GET-запит)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Метод для обробки форми і додавання співробітника (POST-запит)
        [HttpPost]
        public IActionResult Create(Employees newEmployee)
        {
            var employeeList = (_employeesService as MockEmployees).employees;
            if (ModelState.IsValid)
            {
                newEmployee.Id = employeeList.Any() ? employeeList.Max(x => x.Id) + 1 : 1;
                // Додаємо нового співробітника через сервіс
                (_employeesService as MockEmployees)?.AddEmployee(newEmployee);

                // Повертаємо на сторінку з таблицею всіх співробітників
                return RedirectToAction("List", "AllEmployees");
            }
            return View(newEmployee);
        }
    }
}
