using Domain.Entities;
using Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapper
{
    public static class CompanyMapper 
    {
        public static Company ToCompanyDto(CreateCompanyDto company)
        {
            if (company != null)
            {
                return new Company
                {
                    Id=Guid.NewGuid(),
                    Name = company.Name,
                    Address = company.Address,
                    Phone = company.Phone,
                    Email = company.Email,
                    
                };
            }

            return null;
        }
    }
}
