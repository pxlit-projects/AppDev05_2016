using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webapp_stufv.Models {
    public class Article {
        public int Id { get; set; }
        [ForeignKey ( "User" )]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required, MaxLength ( 50 )]
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
        public int ThumbsUp { get; set; }
        public Boolean Active { get; set; }

        
    }
}