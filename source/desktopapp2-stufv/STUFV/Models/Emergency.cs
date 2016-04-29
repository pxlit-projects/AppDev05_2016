using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace STUFV
{
    public class Emergency {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string TelNr { get; set; }
        public Boolean Active { get; set; }

        // Methods
        public static List<Emergency> getAllEmergencies() {
            using ( var context = new STUFVModelContext ( ) ) {
                return context.Emergencies.ToList ( );
            }
        }
    }
}