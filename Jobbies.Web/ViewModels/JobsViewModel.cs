using Jobbies.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobbies.Web.ViewModels
{
    public class JobsViewModel
    {
        public JobsViewModel()
        {
            ListingSummary = new Dictionary<string, int>();

            Listings = new List<DetailViewModel>();
        }

        public Dictionary<string, int> ListingSummary { get; set; }

        public List<DetailViewModel> Listings { get; set; }
    }
}