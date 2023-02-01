using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class TodosServiceJsonPlaceholder : ITodosService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public TodosServiceJsonPlaceholder(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<List<Todo>> GetAll()
        {
            var httpClient = httpClientFactory.CreateClient();
            var result = await httpClient.GetFromJsonAsync<List<Todo>>("https://jsonplaceholder.typicode.com/todos");
            return result;
        }
    }
}
