using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapp_stufv.Models {
    public class Article {
        public int Id { get; set; }
<<<<<<< HEAD

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Campaign")]
        public int CampaignId { get; set; }
        public virtual Campaign Campaign { get; set; }

        [Required, MaxLength(50)]
=======
        public int UserId { get; set; }
        public int CampaignId { get; set; }
>>>>>>> dc185d7d33333bd2d7331607ed0c2d8043caa3af
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
        public int Rating { get; set; }
        public Boolean Active { get; set; }
    }
}