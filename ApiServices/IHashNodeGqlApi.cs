using codeTopGBlazorWasm.Models;

namespace codeTopGBlazorWasm.ApiServices
{
    public interface IHashNodeGqlApi
    {
        Task<HashNodePostModel> GetPost(string slug);
        Task<HashNodeModel> GetAllBlogPosts();
        Task<HashNodeListPostsWithSlugModel> GetListPostsWithSlug(string slug, string hostname);
    }
}
