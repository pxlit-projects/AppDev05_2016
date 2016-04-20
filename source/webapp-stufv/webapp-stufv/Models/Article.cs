using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapp_stufv.Models {
    public class Article {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CampaignId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Date DateTime { get; set; }
        public int Rating { get; set; }
        public Boolean Active { get; set; }
    }
}