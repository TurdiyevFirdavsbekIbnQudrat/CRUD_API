using Domain.Entities;
using Service.DataContext;
using Service.Dtos;
using Service.Interfaces;
using Service.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly AppDbContext dbContext;

        public EmployeeRepository(AppDbContext dbContext) {
            this.dbContext = dbContext;
        }

        public async Task CreateEmployeeAsync(CreateEmployeeDto employee)
        {

            EmployeeMapper employeeCreate = new EmployeeMapper(dbContext);
            var employeeGetData = employeeCreate.ToCompanyDto(employee);
            await dbContext.Employees.AddAsync(employeeGetData);
            await dbContext.SaveChangesAsync();
        }
        public async Task<Employee> GetEmployeeByIdAsync(Guid employeeId)
        {
            var companyData = dbContext.Employees.FirstOrDefault(i => i.Id == employeeId);
            dbContext.SaveChangesAsync();
            return companyData;
        }
        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            var companyAllEmployee  = dbContext.Employees.ToList();
            await dbContext.SaveChangesAsync();
            return companyAllEmployee;
        }
        public async Task<bool> DeleteEmployeeById(Guid employeeId)
        {
            var DeleteElementChoose = dbContext.Employees.FirstOrDefault(i=>i.Id == employeeId);
            if(DeleteElementChoose is not null)
            {
                dbContext.Employees.Remove(DeleteElementChoose);
                await dbContext.SaveChangesAsync();
                return true;
            }
            await dbContext.SaveChangesAsync();
            return false;
        }

      
    }
}
