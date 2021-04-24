using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PieGallery.Models
{
    public class Comics
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String Title { get; set; }

        public String Author { get; set; }

        public String Publisher { get; set; }

        public DateTime ReleaseDate { get; set; }

        public String Streamed { get; set; }

        public String Image { get; set; }

        public int AgeRating { get; set; }

        public float Price { get; set; }

        public Comics()
        {

        }
    }
}
