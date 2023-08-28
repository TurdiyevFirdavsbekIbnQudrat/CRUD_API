using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
using Service.Interfaces;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
            private readonly IStaffRepository staffRepository;
            public StaffsController(IStaffRepository staffRepository)
            {
                this.staffRepository = staffRepository;

            }
            [HttpPost]
            public async Task<IActionResult> CreateStaff([FromForm] CreateStaffDto createStaffDto)
            {
                await staffRepository.CreateStaffAsync(createStaffDto);
                return Ok("Created");
            }
            [HttpGet]
            public async Task<IActionResult> GetStaffs()
            {
                var companies = await staffRepository.GetAllStaffAsync();
                return Ok(companies);
            }
            [HttpGet("{StaffId}")]
            public async Task<IActionResult> GetStaffbyidAsync(Guid EmployeeId)
            {
                var KompaniyaMalumotlari = await staffRepository.GetStaffByIdAsync(EmployeeId);
                return Ok(KompaniyaMalumotlari);
            }
            [HttpDelete("{DeleteById}")]
            public async Task<IActionResult> DeleteFromData(Guid DeleteById)
            {
                bool IsDelete = await staffRepository.DeleteStaffById(DeleteById);
                if (IsDelete == true)
                    return Ok("O'chirildi");
                else
                    return Ok("Bunday ma'lumot oldin ham mavjud emas edi");
            }


        
    }
}
