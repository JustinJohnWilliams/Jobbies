using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobbies.Web.ViewModels
{
    public class ApplyViewModel
    {
        public int ListingId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}