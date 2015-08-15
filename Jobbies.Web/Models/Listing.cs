using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace Jobbies.Web.Models
{
    [Table(Name = "dbo.Listing")]
    public class Listing
    {
        [Column(IsPrimaryKey = true, UpdateCheck = UpdateCheck.Never)]
        public int Id { get; set; }

        [Column]
        public int SponsorId { get; set; }

        [Column]
        public string Title { get; set; }

        [Column]
        public string Description { get; set; }
    }
}