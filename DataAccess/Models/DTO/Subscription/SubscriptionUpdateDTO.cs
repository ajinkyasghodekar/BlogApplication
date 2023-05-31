using System.ComponentModel.DataAnnotations;

namespace BlogApplication.DataAccess.Models.DTO.Subscription
{
    public class SubscriptionUpdateDTO
    {
        [Required]
        public int SubscriptionId { get; set; }

        [Required]
        [EnumDataType(typeof(SubscriptionStatus))]
        public string SubscribeStatus { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }

        [Range(0, 5000, ErrorMessage = "Amount must be a positive value")]
        public int SubscriptionAmount { get; set; }
    }
}
