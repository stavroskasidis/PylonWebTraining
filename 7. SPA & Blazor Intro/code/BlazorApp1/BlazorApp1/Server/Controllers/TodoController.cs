using BlazorApp1.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        //DEMO: DO NOT DO IN REAL LIFE
        static List<TodoItem> ItemStorage { get; set; } = new();

        [HttpGet]
        public List<TodoItem> Get()
        {
            return ItemStorage;
        }

        [HttpPost]
        public void Post(List<TodoItem> items)
        {
            ItemStorage = items;
        }
    }
}
