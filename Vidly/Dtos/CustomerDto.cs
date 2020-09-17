using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto //: Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public virtual MembershipTypeDto MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }

        [DataType(DataType.Date)]
        //[Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}