using WeatherAppBackend.Models;

namespace WeatherAppBackend.Repository
{
    public interface IUserRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(Guid id);
        T Create(T entity);
        User? GetUserByEmail(string Email);
    }
}
