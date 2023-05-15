using NorthwindDb.Models;
using NorthwindDb.Repository;

namespace NorthwindDb.Service
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly northwndContext _northwndContext;

        public EmployeeRepository(northwndContext northwndContext)
        {
            _northwndContext = northwndContext;
        }

        public string CreateEmployee(Employee employee)
        {
            try
            {
                _northwndContext.Employees.Add(employee);
                _northwndContext.SaveChanges();
                return "Çalışan Eklendi!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }

        public string DeleteEmployee(int EmployeeId)
        {
            try
            {
                var deletedId = FindEmployeeById(EmployeeId);
                _northwndContext.Employees.Remove(deletedId);
                _northwndContext.SaveChanges();
                return "Çalışan Silindi!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public Employee FindEmployeeById(int EmployeeId)
        {
            return _northwndContext.Employees.Find(EmployeeId);
        }

        public List<Employee> GetAllEmployees()
        {
            return _northwndContext.Employees.ToList();
        }

        public string UpdateEmployee(Employee employee)
        {
            var updatedId = FindEmployeeById(employee.EmployeeId);
            if (updatedId != null)
            {
                _northwndContext.Entry(updatedId).CurrentValues.SetValues(employee);
                _northwndContext.SaveChanges();
                return "Çalışan Güncellendi";
            }
            else
            {
                return "Çalışan Bulunamadı!";
            }
        }
    }
}
    