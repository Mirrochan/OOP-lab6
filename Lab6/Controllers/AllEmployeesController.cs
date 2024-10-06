using Lab6.Interfaces;
using Lab6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers
{
    public class AllEmployeesController : Controller
    {

        private readonly IEmployees _employeesService;

        public AllEmployeesController(IEmployees employeesService)
        {
            _employeesService = employeesService;
        }


        public IActionResult List()
        {
            var employees = _employeesService.employees;

            return View(employees);
        }

    }
}
