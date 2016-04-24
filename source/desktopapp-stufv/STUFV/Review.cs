using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STUFV
{
    class Review
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int EventId { get; set; }

        public string Content { get; set; }

        public string Status { get; set; }
        public string Flagged { get; set; }

        public int Rating { get; set; }
        public string DateTime { get; set; }
        public Boolean Active { get; set; }
    }
}
