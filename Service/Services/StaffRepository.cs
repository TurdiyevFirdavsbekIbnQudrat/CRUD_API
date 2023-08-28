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
    public class StaffRepository:IStaffRepository
    {
        private readonly AppDbContext dbContext;

        public StaffRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateStaffAsync(CreateStaffDto staffDto)
        {
            var staffCreate = StaffMapper.ToCompanyDto(staffDto);
            await dbContext.Staffs.AddAsync(staffCreate);
            await dbContext.SaveChangesAsync();
        }
        public async Task<Staff> GetStaffByIdAsync(Guid StaffId)
        {
            var staffData = dbContext.Staffs.FirstOrDefault(i => i.Id == StaffId);
            dbContext.SaveChangesAsync();
            return staffData;
        }
        public async Task<List<Staff>> GetAllStaffAsync()
        {
            var Allstaff = dbContext.Staffs.ToList();
            await dbContext.SaveChangesAsync();
            return Allstaff;
        }
        public async Task<bool> DeleteStaffById(Guid StaffId)
        {
            var DeleteElementChoose = dbContext.Staffs.FirstOrDefault(i => i.Id == StaffId);
            if (DeleteElementChoose is not null)
            {
                dbContext.Staffs.Remove(DeleteElementChoose);
                await dbContext.SaveChangesAsync();
                return true;
            }
            await dbContext.SaveChangesAsync();
            return false;
        }

      
    }
}
