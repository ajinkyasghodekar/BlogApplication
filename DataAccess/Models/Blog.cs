﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApplication.DataAccess.Models
{
    public class Blog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogId { get; set; }

        [MaxLength(50)]
        public string BlogTitle { get; set; }

        [MaxLength(200)]
        public string BlogContent { get; set; }

        [MaxLength(30)]
        public string BlogCategory { get; set; }


        [DisplayName("No of Subscriptions Allowed")]
        [Range(0, 100 ,ErrorMessage = "No Of Subscriptions must be between 1-100")]
        public int NoOfSubscriptions { get; set; }

    }
}
