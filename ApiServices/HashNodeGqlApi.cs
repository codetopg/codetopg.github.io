using codeTopGBlazorWasm.Models;
using Microsoft.JSInterop;

namespace codeTopGBlazorWasm.ApiServices
{
    public class HashNodeGqlApi : IHashNodeGqlApi, IDisposable
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
                $" {{ content title }} }}";
            return await js.InvokeAsync<HashNodePostModel>("getHashNodeInterop.getData",query);
        }

        public void Dispose()
        {
            
        }
    }
}
