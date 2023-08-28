using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
using Service.Interfaces;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
            private readonly IEmployeeRepository employeeRepository;
            public EmployeesController(IEmployeeRepository employeeRepository)
            {
                this.employeeRepository = employeeRepository;

            }
            [HttpPost]
            public async Task<IActionResult> CreateEmployee([FromForm] CreateEmployeeDto createEmployeeDto)
            {
                await employeeRepository.CreateEmployeeAsync(createEmployeeDto);
                return Ok("Created");
            }
            [HttpGet]
            public async Task<IActionResult> GetEmployees()
            {
                var companies = await employeeRepository.GetAllEmployeeAsync();
                return Ok(companies);
            }
            [HttpGet("{EmployeeId}")]
            public async Task<IActionResult> GetStaffbyidAsync(Guid EmployeeId)
            {
                var KompaniyaMalumotlari = await employeeRepository.GetEmployeeByIdAsync(EmployeeId);
                return Ok(KompaniyaMalumotlari);
            }
            [HttpDelete("{DeleteById}")]
            public async Task<IActionResult> DeleteFromData(Guid DeleteById)
            {
                bool IsDelete = await employeeRepository.DeleteEmployeeById(DeleteById);
                if (IsDelete == true)
                    return Ok("O'chirildi");
                else
                    return Ok("Bunday ma'lumot oldin ham mavjud emas edi");
            }


        }

    
}
