using WebApp.Services.Interfaces;
using WebApp.Model;
using WebApp.Model.DatabaseModels;

namespace WebAPI.Services.Implementations
{
    public class UserService:IUserService
    {
        private readonly ApplicationContext _db;
        public UserService(ApplicationContext db) => _db = db;

        public IEnumerable<User> GetUsers()
        {
            return _db.Users.ToList();
        }

        public User Get(int id)
        {
            return _db.Users.FirstOrDefault(d => d.Id == id);
        }

        public void Create(User User)
        {
            _db.Users.Add(User);
            _db.SaveChanges();
        }

        public void Update(User User)
        {
            if (!_db.Users.Any(d => d.Id == User.Id))
            {
                return;
            }
            _db.Update(User);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Users.Remove(_db.Users.FirstOrDefault(d => d.Id == id));
            _db.SaveChanges();
        }
    }
}
