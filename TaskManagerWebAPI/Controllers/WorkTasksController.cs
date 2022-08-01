using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DatabaseModels;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkTasksController : ControllerBase
    {
        private IWorkTaskService _workTaskService;
        public WorkTasksController(IWorkTaskService WorkTaskService)
        {
            _workTaskService = WorkTaskService;
        }

        // GET: api/WorkTasks
        [HttpGet]
        public ActionResult<IEnumerable<WorkTask>> GetWorkTasks()
        {
            return Ok(_workTaskService.GetWorkTasks());
        }

        // GET: api/WorkTasks/5
        [HttpGet("{id}")]
        public ActionResult<WorkTask> GetWorkTask(int id)
        {
            var WorkTask = _workTaskService.Get(id);
            if (WorkTask == null)
            {
                return NotFound();
            }
            return Ok(WorkTask);
        }

        // PUT: api/WorkTasks/5
        [HttpPut("{id}")]
        public IActionResult PutWorkTask(int id, WorkTask WorkTask)
        {
            if (id != WorkTask.Id)
            {
                return BadRequest();
            }
            _workTaskService.Update(WorkTask);
            return Ok();
        }

        // POST: api/WorkTasks
        [HttpPost]
        public IActionResult PostWorkTask(WorkTask WorkTask)
        {
            _workTaskService.Create(WorkTask);
            return Ok();
        }

        // DELETE: api/WorkTasks/5
        [HttpDelete("{id}")]
        public IActionResult DeleteWorkTask(int id)
        {
            _workTaskService.Delete(id);
            return Ok();
        }
    }
}
