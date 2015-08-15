using Jobbies.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace Jobbies.Web.Services
{
    public class JobbiesContext : DataContext
    {
        public JobbiesContext(string connectionString)
            : base(connectionString) { }

        internal Table<Sponsor> Sponsors { get { return GetTable<Sponsor>(); } }

        internal Table<Listing> Listings { get { return GetTable<Listing>(); } }

        internal Table<Applicant> Applicants { get { return GetTable<Applicant>(); } }
    }
}