#nullable disable

namespace library.Server.Data
{
    public class Role
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string UserCreated { get; set; }
        public string UserModified { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}