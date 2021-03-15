using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public decimal SignUpFee { get; set; }
        [Range(01, 12)]
        public byte DurationInMonths { get; set; }
        [Range(0, 100)]
        public byte DiscountRate { get; set; }

        //public virtual List<Customer> Customers { get; set; }


        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
        public static readonly byte Monthly = 2;
        public static readonly byte Quaterly = 3;
        public static readonly byte Yearly = 4;

        public enum MembershipTypeEnum : byte
        {
            Unknown = 0,
            PayAsYouGo = 1,
            Monthly = 2,
            Quaterly = 3,
            Yearly = 4
        }
    }
}