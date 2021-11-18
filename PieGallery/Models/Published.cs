using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PieGallery.Models
{
    public class Published
    {
        [Key, Column(Order = 1)]
        public int AuthorId { get; set; }

        [Key, Column(Order = 2)]
        public int PublisherId { get; set; }

        public int Total { get; set; }

        [ForeignKey("AuthorId")]
        public Authors Authors { get; set; }

        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }
    }
}
