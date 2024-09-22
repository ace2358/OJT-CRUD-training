using BLL.DTO;
using DAL.EmployeeRepo;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<EmployeeDTO>> GetEmployees()
        {
            var employees = await _employeeRepo.GetEmployees(); // Call the DAL method
            return employees.Select(e => new EmployeeDTO
            {
                EmpId = e.EmpId,
                Fname = e.Fname,
                Minit = e.Minit,
                Lname = e.Lname,
                JobId = e.JobId,
                JobLvl = e.JobLvl,
                PubId = e.PubId,
                HireDate = e.HireDate
            });
        }

        public async Task<EmployeeDTO> GetEmployee(string id)
        {
            var employee = await _employeeRepo.GetEmployee(id);
            if (employee == null) return null;

            return new EmployeeDTO
            {
                EmpId = employee.EmpId,
                Fname = employee.Fname,
                Minit = employee.Minit,
                Lname = employee.Lname,
                JobId = employee.JobId,
                JobLvl = employee.JobLvl,
                PubId = employee.PubId,
                HireDate = employee.HireDate
            };
        }


        public async Task<bool> UpdateEmployee(string id, EmployeeDTO employeeDTO)
        {
            var existingEmployee = await _employeeRepo.GetEmployee(id);
            if (existingEmployee == null)
            {
                return false;
            }
            existingEmployee.EmpId = employeeDTO.EmpId;
            existingEmployee.Fname = employeeDTO.Fname;
            existingEmployee.Minit = employeeDTO.Minit;
            existingEmployee.Lname = employeeDTO.Lname;
            existingEmployee.JobId = employeeDTO.JobId;
            existingEmployee.JobLvl = employeeDTO.JobLvl;
            existingEmployee.PubId = employeeDTO.PubId;
            existingEmployee.HireDate = employeeDTO.HireDate;

            return await _employeeRepo.UpdateEmployee(id, existingEmployee);
        }


        public async Task<bool> CreateEmployee(EmployeeDTO employeeDto)
        {
            var employee = new Employee
            {
                EmpId = employeeDto.EmpId,
                Fname = employeeDto.Fname,
                Minit = employeeDto.Minit,
                Lname = employeeDto.Lname,
                JobId = employeeDto.JobId,
                JobLvl = employeeDto.JobLvl,
                PubId = employeeDto.PubId,
                HireDate = employeeDto.HireDate
            };
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
