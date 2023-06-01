using System.ComponentModel.DataAnnotations;

namespace BlogApplication.DataAccess.Models.DTO.Blog
{
    public class BlogUpdateDTO
    {
        [Required]
        public int BlogId { get; set; }

        [Required]
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
