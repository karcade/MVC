using WebApp.Services.Interfaces;
using WebApp.Model.DatabaseModels;

namespace WebAPI.Services.Implementations
{
    public class WorkTaskService:IWorkTaskService
    {
        private readonly ApplicationContext _db;
        private readonly Parser.Parser _parser;
        public WorkTaskService(ApplicationContext db) => _db = db;

        public IEnumerable<WorkTask> GetWorkTasks()
        {
            return _db.WorkTasks.ToList();
        }

        public WorkTask Get(int id)
        {
            return _db.WorkTasks.FirstOrDefault(d => d.Id == id);
        }

        public void Create(WorkTask WorkTask)
        {
            _db.WorkTasks.Add(WorkTask);
            _db.SaveChanges();
        }

        public void Update(WorkTask WorkTask)
        {
            if (!_db.WorkTasks.Any(d => d.Id == WorkTask.Id))
            {
                return;
            }
            _db.Update(WorkTask);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.WorkTasks.Remove(_db.WorkTasks.FirstOrDefault(d => d.Id == id));
            _db.SaveChanges();
        }

        public void AddTask()
        {
            var WorkTasks = _parser.GetWorkTask();

            foreach (var WorkTask in WorkTasks)
            {
                _db.WorkTasks.Add(WorkTask);
                _db.SaveChanges();
            }
        }
    }
}
