using WeatherAppBackend.Data;
using WeatherAppBackend.Models;

namespace WeatherAppBackend.Repository.Impl
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User Create(User entity)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Users.Add(entity);
                _context.SaveChanges();
                transaction.Commit();
                return entity;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new BadHttpRequestException(ex.Message);
            }
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(Guid id)
        {
            if (!DoesUserExist(id))
                return new User();
            return _context.Users.Find(id);
        }

        public User? GetUserByEmail(string Email)
        {
            return _context.Users.Where(user => user.Email.Equals(Email)).FirstOrDefault();
           
        }

        private bool DoesUserExist(Guid id)
        {
            return _context.Users.Any(x => x.Id == id);
        }
    }
}
