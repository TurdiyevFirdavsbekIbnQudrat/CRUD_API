using Domain.Entities;
using Service.DataContext;
using Service.Dtos;
using Service.Interfaces;
using Service.Mapper;

namespace Service.Services
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext dbContext;

        public CompanyRepository(AppDbContext appDbContext)
        {
            this.dbContext = appDbContext;
        }
        public async Task CreateCompanyAsync(CreateCompanyDto company)
        {


            var companycreate = CompanyMapper.ToCompanyDto(company);
            await dbContext.Companies.AddAsync(companycreate);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Company>> GetAllAsync()
        {
         var companiesAll=dbContext.Companies.ToList();
         await dbContext.SaveChangesAsync();
         return companiesAll;

        }

        public async Task<Company> GetCompanyByIdAsync(Guid companyId)
        {
            var companiesGetById =dbContext.Companies.FirstOrDefault(i => i.Id == companyId);
            await dbContext.SaveChangesAsync();
            return companiesGetById;
        }
        public async Task<bool> DeleteCompanyById(Guid companyId)
        {
            var companiesGetById = dbContext.Companies.FirstOrDefault(i=>i.Id == companyId);
            if (companiesGetById!=null) {
                dbContext.Companies.Remove(companiesGetById);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}