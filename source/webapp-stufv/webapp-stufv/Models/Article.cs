using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webapp_stufv.Models {
    [Table("Article")]
    public class Article {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User"), Required]
        public int UserId { get; set; }
        public virtual User user { get; set; }

        [ForeignKey("Campaign")]
        public int CampaignId { get; set; }
        public virtual Campaign campaign { get; set; }

        [Required, MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string DateTime { get; set; }
        public int Rating { get; set; }

        [Required]
        public Boolean Active { get; set; }
    }
}