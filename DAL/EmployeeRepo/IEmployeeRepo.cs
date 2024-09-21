using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EmployeeRepo
{
    public interface IEmployeeRepo
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(string id);
        Task<bool> UpdateEmployee(string id, Employee employee);
        Task<bool> CreateEmployee(Employee employee);
        Task<bool> DeleteEmployee(string id);
        bool EmployeeExists(string id);
    }
}