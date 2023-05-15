using Microsoft.AspNetCore.Mvc;
using NorthwindDb.Models;
using NorthwindDb.Repository;

namespace NorthwindDb.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IActionResult Index()
        {
            return View(_employeeRepository.GetAllEmployees());
        }

        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee model)
        { 
            _employeeRepository.CreateEmployee(model);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateEmployee(int id) 
        { 
            return View(_employeeRepository.FindEmployeeById(id)); 
        }

        [HttpPost]
        public IActionResult UpdateEmployee(Employee model)
        {
            var updatedId = _employeeRepository.FindEmployeeById(model.EmployeeId);
            updatedId.FirstName = model.FirstName;
            updatedId.LastName = model.LastName;
            updatedId.Address = model.Address;
            updatedId.City = model.City;
            _employeeRepository.UpdateEmployee(updatedId);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteEmployee(int id)
        { 
            _employeeRepository.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
