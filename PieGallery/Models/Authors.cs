using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PieGallery.Models
{
    public class Authors
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "Author")]
        public String Name { get; set; }

        public char Sex { get; set; }

        public Boolean Active { get; set; }

    }
}
