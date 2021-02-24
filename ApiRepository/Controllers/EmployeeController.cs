using ApiRepository.Models;
using ApiRepository.Paging;
using ApiRepository.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees([FromQuery] PaginParameters paginParameters)
        {
            return await _employeeRepository.GetEmployees(paginParameters); 
        }

        //api/Employees/1
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employee =  _employeeRepository.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }

        [HttpPost]
        public ActionResult<Employee> CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            _employeeRepository.Create(employee);
            return Ok(CreatedAtAction( "Employye id", new { id = employee.Id}, employee));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            var dbemp = _employeeRepository.GetEmployee(id);
            if (!dbemp.Id.Equals(id))
            {
                return NotFound();
            }
            _employeeRepository.UpdateEmployee(employee);

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id) 
        {
            var dbemp = _employeeRepository.GetEmployee(id);           
            if (!dbemp.Id.Equals(id))
            {
                return NotFound();
            }
            _employeeRepository.DeleteEmployee(dbemp);

            return NoContent();

        }


    }
}
