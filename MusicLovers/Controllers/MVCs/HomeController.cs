using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MusicLovers.Core.Contracts;
using MusicLovers.Core.Models;
using MusicLovers.Core.ViewModel;
using MusicLovers.Persistence;
using MusicLovers.Repositories;

namespace MusicLovers.Controllers.MVCs
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Home page.. Show the upcoming gig and search filer
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ActionResult Index(string query = null)
        {
            // Find incoming gigs in the database
            var upcomingGigs = _unitOfWork.Gigs.GetAllUpcomingGigs();

            // Check if there is any query for searching
            if (!String.IsNullOrWhiteSpace(query))
            {
                // Filter by that query
                upcomingGigs = upcomingGigs.Where(g =>
                    g.Artist.Name.Contains(query) || g.Genre.Name.Contains(query) || g.Venue.Contains(query));
            }

            string userId = User.Identity.GetUserId();

            // Create viewModel
            var viewModel = new GigsDisplayViewModel()
            {
                DisplayingGigs = upcomingGigs,
                ShowActions = User.Identity.IsAuthenticated,
                Header = "Upcoming Gigs",
                Attendances = _unitOfWork.Attendances.GetFutureAttendances(userId)
                    .ToLookup(g => g.GigId)              
            };

            return View("Gigs", viewModel);
        }


    }
}