using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApplication.DataAccess.Models.DTO.Subscription
{
    public class SubscriptionCreateDTO
    {
        [Required]
        [EnumDataType(typeof(SubscriptionStatus))]
        public string SubscribeStatus { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }

        [Range(0, 5000, ErrorMessage = "Amount must be a positive value")]
        public int SubscriptionAmount { get; set; }

        public int UserId { get; set; }
        public int BlogId { get; set; }
    }
}
