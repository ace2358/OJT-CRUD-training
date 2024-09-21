using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EmployeeService
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(string id);
        Task<bool> UpdateEmployee(string id, Employee employee);
        Task<bool> CreateEmployee(Employee employee);
        Task<bool> DeleteEmployee(string id);
        bool EmployeeExists(string id);
    }
}
