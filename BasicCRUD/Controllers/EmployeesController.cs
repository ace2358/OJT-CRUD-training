using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entities;
using BLL.EmployeeService;

namespace BasicCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly PubsContext _context;
        private readonly IEmployeeService _employeeService;

        public EmployeesController(PubsContext context, IEmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return Ok(await _employeeService.GetEmployees());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(string id)
        {
            var employee = await _employeeService.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(string id, Employee employee)
        {
            if (id != employee.EmpId)
            {
                return BadRequest();
            }

            if (await _employeeService.UpdateEmployee(id, employee))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            if (await _employeeService.CreateEmployee(employee))
            {
                return CreatedAtAction("GetEmployee", new { id = employee.EmpId }, employee);
            }
            else if (_employeeService.EmployeeExists(employee.EmpId))
            {
                return Conflict();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            if (await _employeeService.DeleteEmployee(id))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
