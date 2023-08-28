using Domain.Entities;
using Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IStaffRepository
    {
        public  Task<List<Staff>> GetAllStaffAsync();
        public Task CreateStaffAsync(CreateStaffDto staffDto);
        public Task<Staff> GetStaffByIdAsync(Guid StaffId);
        public Task<bool> DeleteStaffById(Guid StaffId);

    }
}
