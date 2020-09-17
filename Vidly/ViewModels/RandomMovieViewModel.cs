using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie{ get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}