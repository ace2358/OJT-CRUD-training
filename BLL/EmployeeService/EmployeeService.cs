using DAL.EmployeeRepo;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeService(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _employeeRepo.GetEmployees();
        }

        public async Task<Employee> GetEmployee(string id)
        {
            return await _employeeRepo.GetEmployee(id);
        }

        public async Task<bool> UpdateEmployee(string id, Employee employee)
        {
            return await _employeeRepo.UpdateEmployee(id, employee);
        }

        public async Task<bool> CreateEmployee(Employee employee)
        {
            return await _employeeRepo.CreateEmployee(employee);
        }

        public async Task<bool> DeleteEmployee(string id)
        {
            return await _employeeRepo.DeleteEmployee(id);
        }

        public bool EmployeeExists(string id)
        {
            return _employeeRepo.EmployeeExists(id);
        }
    }
}
