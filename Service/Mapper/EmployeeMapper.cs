using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.DataContext;
using Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapper
{
    public class EmployeeMapper
    {
        private readonly AppDbContext dbContext;

        public EmployeeMapper(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public Employee ToCompanyDto(CreateEmployeeDto employee)
        {

            if (employee != null)
            {
                return new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Phone = employee.Phone,
                    Email = employee.Email,
                    CompanyId = IdCompany(employee),

            };
            }

            return null;
        }
        private Guid IdCompany(CreateEmployeeDto employee)
        {
            var CompanyGuid = dbContext.Companies.Where(i => i.Email == employee.Email)
                .FirstOrDefault(e => e.Phone == employee.Phone);
            if (CompanyGuid != null)
            {
                return CompanyGuid.Id;
            }
            else
            {
                return Guid.Empty;
            }
        }
    }
}
