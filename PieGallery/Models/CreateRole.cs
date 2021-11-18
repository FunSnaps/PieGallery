using System.ComponentModel.DataAnnotations;

namespace PieGallery.Models
{
    public class CreateRole
    {
        [Required]
        public string RoleName { get; set; }

        public int Id { get; set; }
    }
}
