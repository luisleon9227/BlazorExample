using WebBlazor.Models;

namespace WebBlazor.Services.Interfaces
{
    public interface IPostsService
    {
        public Task<List<Post>> Get();

        public Task Add(Post post);

        public Task Delete(int id);
    }
}
