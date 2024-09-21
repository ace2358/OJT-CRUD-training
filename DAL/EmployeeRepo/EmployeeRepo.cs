using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EmployeeRepo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly PubsContext _context;

        public EmployeeRepo(PubsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployee(string id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<bool> UpdateEmployee(string id, Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteEmployee(string id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public bool EmployeeExists(string id)
        {
            return _context.Employees.Any(e => e.EmpId == id);
        }
    }
}
