using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace Jobbies.Web.Models
{
    [Table(Name = "dbo.Applicant")]
    public class Applicant
    {
        [Column(IsPrimaryKey = true, UpdateCheck = UpdateCheck.Never, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column]
        public int ListingId { get; set; }

        [Column]
        public string FirstName { get; set; }

        [Column]
        public string LastName { get; set; }

        [Column]
        public string Email { get; set; }

        [Column]
        public string Phone { get; set; }
    }
}