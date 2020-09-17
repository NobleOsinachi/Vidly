using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }
        public virtual ICollection<MembershipType> MembershipTypes { get; set; }
    }
}