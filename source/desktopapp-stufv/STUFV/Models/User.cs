﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace STUFV
{
    [Table ( "User" )]
    public class User {
        [Key]
        public int Id { get; set; }

        [MaxLength(30), Required]
        public string FirstName { get; set; }

        [MaxLength(30), Required]
        public string LastName { get; set; }

        [MaxLength(40), Required]
        public string PassWord { get; set; }
        public string Salt { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string BirthPlace { get; set; }

        public string Sex { get; set; }

        [Required]
        public string Street { get; set; }
        [ForeignKey("Cities")]
        public string ZipCode { get; set; }
        public virtual Cities Cities { get; set; }

        [MaxLength(30), Required]
        public string Email { get; set; }

        public string TelNr { get; set; }
        public string MobileNr { get; set; }
        public string ProfilePicture { get; set; }

        [ForeignKey("UserTypes")]
        public int RoleID { get; set; }
        public virtual UserTypes UserTypes { get; set; }

        [Required]
        public Boolean Active { get; set; }

        public DateTime? RegisterDate { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Logout> Logins { get; set; }

        public virtual ICollection<Logout> Logouts { get; set; }

        public virtual ICollection<DesDriver> DesDrivers { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public virtual ICollection<Organisation> Organisations { get; set; }

        // Methods

    }
}