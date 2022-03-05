using System.ComponentModel.DataAnnotations;

namespace Library.ViewModel
{
    public class CreateRoleViewModel
    
    {
       
        [Required]
        public string? RoleName { get; set; }    }
}
