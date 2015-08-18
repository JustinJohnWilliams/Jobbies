using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jobbies.Web.Models;

namespace Jobbies.Web.ViewModels
{
    public class DetailViewModel: Listing
    {
        public string SponsorName { get; set; }
    }
}