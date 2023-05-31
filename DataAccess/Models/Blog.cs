using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApplication.DataAccess.Models
{
    public class Blog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        public string BlogTitle { get; set; }

        [MaxLength(200)]
        public string BlogContent { get; set; }

        [MaxLength(30)]
        public string BlogCategory { get; set; }

        [Range(0, 100)]
        public int NoOfSubscriptions { get; set; }

    }
}
