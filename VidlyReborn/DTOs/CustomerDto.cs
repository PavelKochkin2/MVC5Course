using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyReborn.Models;

namespace VidlyReborn.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the fucking name!!!")]
        [StringLength(255)]
        public string Name { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        //[Min18YearsToGoOnMembership]
        public byte MembershipTypeId { get; set; }

        public DateTime? BirthDay { get; set; }
    }
}