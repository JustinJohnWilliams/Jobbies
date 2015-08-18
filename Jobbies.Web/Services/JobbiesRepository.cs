using Jobbies.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobbies.Web.Services
{
    public class JobbiesRepository
    {
        private string _connectionString;

        public JobbiesRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Sponsor> GetSponsors()
        {
            var results = new List<Sponsor>();

            using (JobbiesContext context = new JobbiesContext(_connectionString))
            {
                results = context.GetTable<Sponsor>().ToList();
            }

            return results;
        }

        public Sponsor GetSponsor(int id)
        {
            using (var context = new JobbiesContext(_connectionString))
            {
                return context.Sponsors.FirstOrDefault(c => c.Id == id);
            }
        }

        public List<Listing> GetListings(int sponsorId)
        {
            List<Listing> results;

            using (JobbiesContext context = new JobbiesContext(_connectionString))
            {
                var things =
                    from sponsors in context.Sponsors
                    join listings in context.Listings
                    on sponsors.Id equals listings.SponsorId
                    select listings;

                results = things.ToList();
                    
            }

            return results;
        }

        public List<Listing> GetListings()
        {
            List<Listing> results;

            using (JobbiesContext context = new JobbiesContext(_connectionString))
            {
                results = context.GetTable<Listing>().ToList();
            }

            return results;
        }

        public Listing GetListing(int id)
        {
            using (var context = new JobbiesContext(_connectionString))
            {
                return context.Listings.FirstOrDefault(c => c.Id == id);
            }
        }

        public Applicant Add(Applicant applicant)
        {
            using (var context = new JobbiesContext(_connectionString))
            {
                context.Applicants.InsertOnSubmit(applicant);

                context.SubmitChanges();
            }

            //TODO: return updated applicant with ID
            return applicant;
        }

    }
}