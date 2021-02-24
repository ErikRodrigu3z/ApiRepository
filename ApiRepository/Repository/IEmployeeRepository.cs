using ApiRepository.Models;
using ApiRepository.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRepository.Repository
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        Task<PagedList<Employee>> GetEmployees(PaginParameters paginParameters);
        Employee GetEmployee(int id);
        void CreateEmployee(Employee employee); 
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);



    }
}
