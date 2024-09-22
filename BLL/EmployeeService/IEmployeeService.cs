using BLL.DTO;
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
        Task<IEnumerable<EmployeeDTO>> GetEmployees();
        Task<EmployeeDTO> GetEmployee(string id);
        Task<bool> UpdateEmployee(string id, EmployeeDTO EmployeeDTO);
        Task<bool> CreateEmployee(EmployeeDTO employeeDto);
        Task<bool> DeleteEmployee(string id);
        bool EmployeeExists(string id);
    }
}
