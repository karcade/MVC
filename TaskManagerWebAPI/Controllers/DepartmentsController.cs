using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DatabaseModels;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private IDepartmentService _departmentService;
        public DepartmentsController(IDepartmentService DepartmentService)
        {
            _departmentService = DepartmentService;
        }

        // GET: api/Departments
        [HttpGet]
        public ActionResult<IEnumerable<Department>> GetDepartments()
        {
            return Ok(_departmentService.GetDepartments());
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public ActionResult<Department> GetDepartment(int id)
        {
            var Department = _departmentService.Get(id);
            if (Department == null)
            {
                return NotFound();
            }
            return Ok(Department);
        }

        // PUT: api/Departments/5
        [HttpPut("{id}")]
        public IActionResult PutDepartment(int id, Department Department)
        {
            if (id != Department.Id)
            {
                return BadRequest();
            }
            _departmentService.Update(Department);
            return Ok();
        }

        // POST: api/Departments
        [HttpPost]
        public IActionResult PostDepartment(Department Department)
        {
            _departmentService.Create(Department);
            return Ok();
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            _departmentService.Delete(id);
            return Ok();
        }
    }
}
