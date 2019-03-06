using System;
using System.ComponentModel.DataAnnotations;

namespace VidlyReborn.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the fucking name!!!")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        [Min18YearsToGoOnMembership]
        public byte MembershipTypeId { get; set; }

        public DateTime? BirthDay { get; set; }
    }
}