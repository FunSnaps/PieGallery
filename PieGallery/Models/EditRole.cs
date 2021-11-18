using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PieGallery.Models
{
    public class EditRole
    {
        public EditRole()
        {
            Users = new List<string>();
        }

        public string Id { get; set; }

        [Required(ErrorMessage = "RoleName is required!")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}
