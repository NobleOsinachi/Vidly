using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MembershipTypeDto // : MembershipType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}