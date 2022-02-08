using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Costumer
    {
        public int CostumerID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        public ICollection<Rent>? Rent { get; set; }
    }
}
