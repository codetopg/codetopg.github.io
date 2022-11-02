namespace codeTopGBlazorWasm.Models
{
      public class HashNodeListPostsWithSlugModel
    {
        public DataPostsWithSlug data { get; set; }
    }

    public class DataPostsWithSlug
    {
        public PostWithSlug post { get; set; }
    }

    public class PostWithSlug
    {
        public PublicationWithSlug publication { get; set; }
    }

    public class PublicationWithSlug
    {
        public string username { get; set; }
        public Posts[] posts { get; set; }
    }

    public class Posts
    {
        public string cuid { get; set; }
        public string slug { get; set; }
        public string title { get; set; }
        public float popularity { get; set; }
        public DateTime dateAdded { get; set; }
        public string brief { get; set; }
        public DateTime? dateUpdated { get; set; }
        public string coverImage { get; set; }
    }

}
