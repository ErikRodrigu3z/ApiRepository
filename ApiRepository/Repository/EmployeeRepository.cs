using ApiRepository.Models;
using ApiRepository.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRepository.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
        }

        public void CreateEmployee(Employee employee)
        {
            Create(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            Update(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }

        public Employee GetEmployee(int id)
        {
            return FindByCondition(x => x.Id == id).FirstOrDefault();
        }

        public Task<PagedList<Employee>> GetEmployees(PaginParameters paginParameters)
        {
            return Task.FromResult(PagedList<Employee>.GetPagedList(FindAll().OrderBy(x => x.Id),paginParameters.PageNumber,paginParameters.PageSize));
        }

       
    }
}
