using NorthwindDb.Models;

namespace NorthwindDb.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();
        Employee FindEmployeeById(int EmployeeId);
        string CreateEmployee(Employee employee);
        string UpdateEmployee(Employee employee);
        string DeleteEmployee(int EmployeeId);
    }
}
