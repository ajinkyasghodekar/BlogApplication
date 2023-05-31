using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApplication.DataAccess.Models
{
    public class Subscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubscriptionId { get; set; }

        [Required]
        [EnumDataType(typeof(SubscriptionStatus))]
        public string SubscribeStatus { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
        public int SubscriptionAmount { get; set; }


        [ForeignKey("Users")]
        public int UserId { get; set; }

        [ForeignKey("Blog")]
        public int BlogId { get; set; }

        public Users Users { get; set; }
        public Blog Blog { get; set; }

    }
    public enum SubscriptionStatus
    {
        Approved,
        Rejected,
        Processing
    }
}
