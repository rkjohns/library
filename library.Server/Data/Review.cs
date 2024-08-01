#nullable disable

namespace library.Server.Data
{
    public class Review
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public string UserCreated { get; set; }
        public string UserModified { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
