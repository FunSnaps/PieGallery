using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PieGallery.Models
{
    public class EditRole
    {
        public EditRole()
        {
            Users = new List<string>(); 
        }

        public string Id { get; set; }

        [Required(ErrorMessage ="RoleName is required!")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}
