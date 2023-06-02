using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace DataAccess.Models
{
    public class Blog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogId { get; set; }

        [MaxLength(50)]
        [DisplayName("Blog Title")]
        public string BlogTitle { get; set; }

        [MaxLength(200)]
        [DisplayName("Blog Content")]
        public string BlogContent { get; set; }

        [MaxLength(30)]
        [DisplayName("Blog Category")]
        public string BlogCategory { get; set; }

        [Required]
        [DisplayName("No of Subscriptions Allowed")]
        [Range(0, 100 ,ErrorMessage = "No Of Subscriptions must be between 1-100")]
        public int NoOfSubscriptions { get; set; }

    }
}
