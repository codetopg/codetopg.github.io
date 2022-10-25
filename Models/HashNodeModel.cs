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
        public string title { get; set; }
        public string brief { get; set; }
        public string slug { get; set; }
        public string coverImage { get; set; }

    }

}
