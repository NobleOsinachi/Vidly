using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        //associate a customer with MembershipType Navigation Property
        public virtual MembershipType MembershipType { get; set; }

        //[ForeignKey("MembershipType")]
        public byte MembershipTypeId { get; set; }

        [DataType(DataType.Date)]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}