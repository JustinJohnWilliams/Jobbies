using Jobbies.Web.Models;
using Jobbies.Web.Services;
using Jobbies.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jobbies.Web.Controllers
{
    public class HomeController : Controller
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings["Jobbies"].ConnectionString;

        public readonly JobbiesRepository _repo;

        public HomeController()
        {
            _repo = new JobbiesRepository(ConnectionString);
        }

        public ActionResult Index()
        {
            var sponsors = _repo.GetSponsors();

            var listings = _repo.GetListings();

            var vm = new JobsViewModel();

            foreach (var listing in listings)
            {
                vm.ListingSummary.Add(
                    _repo.GetSponsor(
                            listing.SponsorId).Name, 
                            listings.Count(c => c.SponsorId == listing.SponsorId));
            }

            return View(vm);
        }

        public ActionResult Apply(int? listingId)
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

            return View(new ApplyViewModel { ListingId = listing.Id });
        }

        [HttpPost]
        public ActionResult Apply(ApplyViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            _repo.Add(new Applicant
                {
                    ListingId = model.ListingId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Phone = model.Phone
                });

            return View(model);
        }

    }
}
