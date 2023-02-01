using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class MockTodosService : ITodosService
    {
        public Task<List<Todo>> GetAll()
        {
            return Task.FromResult(new List<Todo> 
            {
                new Todo()
                {
                    Completed= true,
                    Title = "Mock todo 1"
                },
                new Todo()
                {
                    Completed= false,
                    Title = "Mock todo 2"
                }
            });
        }
    }
}
