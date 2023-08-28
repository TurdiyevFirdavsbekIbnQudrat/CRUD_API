using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos;
using Service.Interfaces;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository companyRepository;
        public CompaniesController(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
            
        }
        [HttpPost]
        public async Task<IActionResult> CreateCompany ([FromForm] CreateCompanyDto createCompanyDto)
        {
            await companyRepository.CreateCompanyAsync(createCompanyDto);
            return Ok("Created");
        }
        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies  = await companyRepository.GetAllAsync();
            return Ok(companies);
        }
        [HttpGet("{companyid}")]
        public async Task<IActionResult> GetCompanybyidAsync(Guid companyid)
        {
            var KompaniyaMalumotlari = await companyRepository.GetCompanyByIdAsync(companyid);
            return Ok(KompaniyaMalumotlari);
        }
        [HttpDelete("{DeleteById}")]
        public async Task<IActionResult> DeleteFromData(Guid DeleteById)
        {
            bool IsDelete = await companyRepository.DeleteCompanyById(DeleteById);
            if (IsDelete == true)
                return Ok("O'chirildi");
            else
            return Ok("Bunday ma'lumot oldin ham mavjud emas edi");
        }
    }

}
