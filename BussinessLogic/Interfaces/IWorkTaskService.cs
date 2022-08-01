using WebApp.Model.DatabaseModels;

namespace WebApp.Services.Interfaces
{
    public interface IWorkTaskService
    {
        IEnumerable<Tea> GetTeas();
        Tea Get(int id);
        void Create(Tea Tea);
        void Update(Tea Tea);
        void Delete(int id);
        void AddTask();
    }
}
