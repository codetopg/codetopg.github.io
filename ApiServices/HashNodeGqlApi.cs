using codeTopGBlazorWasm.Models;
using Microsoft.JSInterop;

namespace codeTopGBlazorWasm.ApiServices
{
    public class HashNodeGqlApi : IHashNodeGqlApi
    {
        private readonly IJSRuntime js;

        public HashNodeGqlApi(IJSRuntime js)
        {
            this.js = js;
        }

        public async Task<HashNodeModel> GetAllBlogPosts()
        {
            string query = "{user(username: \"codetopg\")" +
                " {publication {posts(page: 0) " +
                "{slug title brief coverImage dateUpdated }}}}";
            return await js.InvokeAsync<HashNodeModel>("getHashNodeInterop.getData", query);
        }

        public async Task<HashNodePostModel> GetPost(string slug)
        {
            string query = $"{{post(slug:\"{slug}\", hostname:\"\")" +
                $" {{ slug title dateAdded content coverImage }} }}";
            return await js.InvokeAsync<HashNodePostModel>("getHashNodeInterop.getData",query);
        }

        public async Task<HashNodeListPostsWithSlugModel> GetListPostsWithSlug(string slug, string hostname) 
        {
            string query = $"{{post(slug:\"{slug}\", hostname:\"{hostname}\")" +
                $" {{ publication {{ username posts " +
                $" {{ cuid slug title popularity dateAdded brief dateUpdated coverImage }} }} }} }}";
            Console.WriteLine("GetListPostsWithSlug " + query);
            return await js.InvokeAsync<HashNodeListPostsWithSlugModel>("getHashNodeInterop.getData", query);
        
        }

        //public void Dispose()
        //{
        //}
    }
}
