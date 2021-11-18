using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PieGallery.Models
{
    public class Comics
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public String Title { get; set; }

        public int AuthorId { get; set; }

        public int PublisherId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public String ComicImage { get; set; }

        public int AgeRating { get; set; }

        public float Price { get; set; }

        [ForeignKey("AuthorId")]
        public Authors Authors { get; set; }

        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }

        public Comics()
        {

        }
    }
}
