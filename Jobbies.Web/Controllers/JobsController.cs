using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jobbies.Web.Models;
using Jobbies.Web.Services;
using Jobbies.Web.ViewModels;

namespace Jobbies.Web.Controllers
{
    public class JobsController: Controller
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Jobbies"].ConnectionString;
        private readonly JobbiesRepository _repo;

        public JobsController()
        {
            _repo = new JobbiesRepository(_connectionString);
        }

        public ActionResult Index()
        {
            var listings = _repo.GetListings();

            var vm = new JobsViewModel();
            var sponsors = new Dictionary<int, Sponsor>();

            foreach (var listing in listings)
            {
                if (!sponsors.ContainsKey(listing.SponsorId))
                {
                    sponsors.Add(listing.SponsorId, _repo.GetSponsor(listing.SponsorId));
                }

                vm.Listings.Add(new DetailViewModel()
                {
                    SponsorId = listing.SponsorId,
                    Description = listing.Description,
                    Title = listing.Title,
                    SponsorName = sponsors[listing.SponsorId].Name,
                    Id = listing.Id
                });
            }

            vm.ListingSummary = sponsors.ToDictionary(d => d.Value.Name, d => listings.Count(c => c.SponsorId == d.Key));

            return View(vm);
        }

        public ActionResult Detail(int? listingId)
        {
            if (listingId == null)
            {
                return RedirectToAction("Index");
            }

            var listing = _repo.GetListing(listingId.Value);

            if (listing == null)
            {
                return RedirectToAction("Index");
            }

            var sponsor = _repo.GetSponsor(listing.SponsorId);
            if (sponsor == null)
            {
                return RedirectToAction("Index");
            }

            var detail = new DetailViewModel()
            {
                SponsorId = listing.SponsorId,
                Description = listing.Description,
                Title = listing.Title,
                Id = listing.Id,
                SponsorName = sponsor.Name
            };

            return View(detail);
        }

        [HttpPost]
        public ActionResult Apply(ApplyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Detail", new { listingId = model.ListingId });
            }

            _repo.Add(new Applicant
            {
                ListingId = model.ListingId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Phone = model.Phone
            });

            return RedirectToAction("Detail", new { listingId = model.ListingId });
        }
    }
}