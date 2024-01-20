using System.Net.Http.Json;
using System.Text.Json;
using WebBlazor.Models;
using WebBlazor.Services.Interfaces;

namespace WebBlazor.Services
{
    public class PostsServices : IPostsService
    {
        private readonly HttpClient _httpClient;

        private readonly JsonSerializerOptions options;

        public PostsServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
            options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task Add(Post post)
        {
            var response = await _httpClient.PostAsync("posts", JsonContent.Create(post));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }

        public async Task Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"posts/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }

        public async Task<List<Post>> Get()
        {
            var response = await _httpClient.GetAsync("posts");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            return JsonSerializer.Deserialize<List<Post>>(content, options);
        }
    }
}
