using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface ITodosService
    {
        Task<List<Todo>> GetAll();
    }
}
