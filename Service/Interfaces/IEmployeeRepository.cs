using Domain.Entities;
using Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IEmployeeRepository
    {

        public Task CreateEmployeeAsync(CreateEmployeeDto employee);
        public Task<Employee> GetEmployeeByIdAsync(Guid employeeId);
        public Task<List<Employee>> GetAllEmployeeAsync();
        public Task<bool> DeleteEmployeeById(Guid employeeId);
    }
}
