using Microsoft.AspNetCore.Components;

namespace codeTopGBlazorWasm.Models
{

    public class HashNodeModel
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public User user { get; set; }
    }

    public class User
    {
        public Publication publication { get; set; }
    }

    public class Publication
    {
        public Post[] posts { get; set; }
    }

    public class Post
    {
        public string cuid { get; set; }
        public string slug { get; set; }
        public string title { get; set; }
        public float popularity { get; set; }
        public int totalReactions { get; set; }
        public bool partOfPublication { get; set; }
        public DateTime dateAdded { get; set; }
        public string brief { get; set; }
        public DateTime? dateUpdated { get; set; }
        public object dateFeatured { get; set; }
        public string coverImage { get; set; }
    }

}
