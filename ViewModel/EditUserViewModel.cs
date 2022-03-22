using System.ComponentModel.DataAnnotations;

namespace Library.ViewModel
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {

            Roles = new List<string>();
        }

        public string Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }


        public IList<string> Roles { get; set; }
    }
}