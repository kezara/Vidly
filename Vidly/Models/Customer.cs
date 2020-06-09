using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please enter customer's name")]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
        
        public bool IsSubscribedToNewsLetter { get; set; }
        //navigation property for navigating between types
        
        public MembershipType MembershipType { get; set; }

        //foreign key
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}