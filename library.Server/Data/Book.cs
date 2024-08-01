#nullable disable

namespace library.Server.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string CoverImageUrl { get; set; }
        public string Publisher { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Category { get; set; }
        public int ISBN { get; set; }
        public int PageCount { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string UserCreated { get; set; }
        public string UserModified { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
