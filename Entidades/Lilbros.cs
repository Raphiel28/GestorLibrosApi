namespace GerstorLibrosAPI.Entidades
{
    public class Lilbros
    {

        public Lilbros(int id, string title, string description, int pageCount, string excerpt, DateTime datePublish) { 

            Id = id;
            Title = title;
            Description = description;
            PageCount = pageCount;
            Excerpt = excerpt;
            DatePublish = datePublish;
        
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int PageCount { get; set; }

        public string Excerpt { get; set; }

        public DateTime DatePublish { get; set; }
        
    }
}
