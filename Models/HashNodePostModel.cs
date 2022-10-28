namespace codeTopGBlazorWasm.Models
{
    public class HashNodePostModel
    {
        public DataPost data { get; set; }
    }

    public class DataPost
    {
        public PostData post { get; set; }
    }

    public class PostData
    {
        public string slug { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public bool partOfPublication { get; set; }
        public DateTime dateUpdated { get; set; }
        public float popularity { get; set; }
        public DateTime dateAdded { get; set; }
        public string content { get; set; }
        public string brief { get; set; }
        public string coverImage { get; set; }
    }

}
