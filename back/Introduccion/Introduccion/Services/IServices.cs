using Introduccion.Models;

namespace Introduccion.Services
{
    public interface IServices<T> where T : class
    {
        List<T> GetAll();
    }
}
