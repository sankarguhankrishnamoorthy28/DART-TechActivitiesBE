using EmployeeApp.Model;
using EmployeeApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeService employeeService=new EmployeeService();
        public EmployeeController()
        {

        }
        //[HttpGet("{pageNumber}")]
        //public IList<Employee> GetAllEmployees(int pageNumber, string sortOrder,string sortingColumn)
        //{
        //    return employeeService.GetAllEmployees(pageNumber,sortOrder,sortingColumn);
        //}

        [HttpPost]
        public IList<Employee> PostAllEmployees([FromBody]EmployeePost employeePost)
        {
            return employeeService.GetAllEmployees(employeePost.pageNumber, employeePost.sortOrder, employeePost.sortingColumn);
        }
    }
}
