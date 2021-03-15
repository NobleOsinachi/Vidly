using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min18YearsIfAMemberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //First check the selected membership type
            var customer = (Customer)validationContext.ObjectInstance;
            //check the selected membership type

            //using enum 
            /**
            if (customer.MembershipTypeId == (byte)MembershipTypeEnum. Unknown || 
                customer.MembershipTypeId == (byte)MembershipTypeEnum.PayAsYouGo)
            */
            if (customer.MembershipTypeId == MembershipType.Unknown ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            if (customer.BirthDate == null)
                return new ValidationResult("Birthdate is required");
            new DateTime(); 

            //calc the age
            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult(@"Customer should be at least 18 years old to go on a membership.");
        }
    }

    public struct RoleName
    {
        public const string CanManageMovies = "CanManageMovies";
    }
    public enum Status : byte
    {
        Expired,
        Active,
        Deactivated,
    }
}