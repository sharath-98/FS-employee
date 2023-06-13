using FullstackAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FullstackAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class EmployeesController : Controller
    {
        private DataContext _dataContext;
        public EmployeesController( DataContext _context) {
            _dataContext = _context;        
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _dataContext.Employees.ToListAsync();
            return Ok(employees);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _dataContext.Employees.Add(employee);
            await _dataContext.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpGet("edit/{id:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var employee = await _dataContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPut("edit/{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, Employee updatedEmployee)
        {
            var employee = await _dataContext.Employees.FindAsync(id);
            if(employee == null)
            {
                return NotFound(id);
            }
            employee.Name = updatedEmployee.Name;
            employee.Salary = updatedEmployee.Salary;
            employee.Email = updatedEmployee.Email;
            employee.Dept = updatedEmployee.Dept;
            employee.Phone = updatedEmployee.Phone;

            await _dataContext.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpDelete("delete/{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await _dataContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _dataContext.Employees.Remove(employee);
            await _dataContext.SaveChangesAsync();

            return Ok(employee);
        }
    }
}
