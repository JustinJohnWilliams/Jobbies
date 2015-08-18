using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace Jobbies.Web.Models
{
    [Table(Name = "dbo.Sponsor")]
    public class Sponsor
    {
        [Column(IsPrimaryKey = true, UpdateCheck = UpdateCheck.Never)]
        public int Id { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public string ContactName { get; set; }

        [Column]
        public string ContactNumber { get; set; }

        [Column]
        public string Website { get; set; }
    }
}