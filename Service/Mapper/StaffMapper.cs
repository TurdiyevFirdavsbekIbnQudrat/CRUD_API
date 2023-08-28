using Domain.Entities;
using Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapper
{
    public class StaffMapper
    {
        public static Staff ToCompanyDto(CreateStaffDto staff)
        {
            if (staff != null)
            {
                return new Staff
                {
                    Id = Guid.NewGuid(),
                    Name = staff.Name,

                };
            }

            return null;
        }
    }
}
