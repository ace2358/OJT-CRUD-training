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
using BLL.DTO;
using BasicCRUD.InputForms.Employee;

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
        public async Task<IActionResult> PutEmployee(string id, EmployeeForm2 employeeForm)
        {
            if (!_employeeService.EmployeeExists(id))
            {
                return BadRequest();
            }

            var hireDate = new DateTime(employeeForm.HireYear, employeeForm.HireMonth, employeeForm.HireDay);

            var employeeDto = new EmployeeDTO
            {
                EmpId = id,
                Fname = employeeForm.Fname,
                Minit = employeeForm.Minit,
                Lname = employeeForm.Lname,
                JobId = employeeForm.JobId,
                JobLvl = employeeForm.JobLvl,
                PubId = employeeForm.PubId,
                HireDate = hireDate
            };

            if (await _employeeService.UpdateEmployee(id, employeeDto))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }



        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> PostEmployee([FromBody] EmployeeForm employeeForm)
        {
            if (employeeForm == null)
            {
                return BadRequest("Employee's data is null");
            }

            if (_employeeService.EmployeeExists(employeeForm.EmpId))
            {
                return Conflict("Employee with the same ID already exists");
            }

            var employee = new EmployeeDTO
            {
                EmpId = employeeForm.EmpId,
                Fname = employeeForm.Fname,
                Minit = employeeForm.Minit,
                Lname = employeeForm.Lname,
                JobId = employeeForm.JobId,
                JobLvl = employeeForm.JobLvl,
                PubId = employeeForm.PubId,
                HireDate = new DateTime(employeeForm.HireYear, employeeForm.HireMonth, employeeForm.HireDay)
            };

            if (await _employeeService.CreateEmployee(employee))
            {
                return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmpId }, employeeForm);
            }

            return BadRequest("An error occurred while creating the employee.");
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
