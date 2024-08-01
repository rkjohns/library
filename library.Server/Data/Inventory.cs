#nullable disable

namespace library.Server.Data
{
    public class Inventory
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public bool IsCheckedOut { get; set; } = false;
        public DateTime? CheckoutDate { get; set; }
        public string UserCreated { get; set; }
        public string UserModified { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
