using WebApp.Model.DatabaseModels;

namespace WebApp.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User Get(int id);
        void Create(User User);
        void Update(User User);
        void Delete(int id);
    }
}
