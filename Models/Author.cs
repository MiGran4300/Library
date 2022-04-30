using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        // user ID from AspNetUser table.
        public string? OwnerID { get; set; }
        [DisplayName("Автор")]
        public string? FullName { get; set; }
        
        
        [DisplayName ("Факултет")]
        public string? Department { get; set; }

        [DisplayName("Курс")]
        public int? Grade { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string? Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public int? Phone { get; set; }
        
        public ICollection<Book>? Books { get; set; }

       
    }
}
