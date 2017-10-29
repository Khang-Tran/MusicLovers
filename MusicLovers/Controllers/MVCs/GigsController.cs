using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MusicLovers.Core.Contracts;
using MusicLovers.Core.Models.Entities;
using MusicLovers.Core.ViewModel;
using MusicLovers.Persistence;
using MusicLovers.Repositories;

namespace MusicLovers.Controllers.MVCs
{
    [Authorize]
    public class GigsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public GigsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Initialize GigForm, fill the Genres in
        /// </summary>
        /// <returns>
        /// An empty GigForm with choices for Genre
        /// </returns>
        public ActionResult Create()
        {
            var viewModel = new GigsFormViewModel()
            {
                Heading = "Create a Gig",
                Genres = _unitOfWork.Genres.GetAllGenres()
            };
            return View("GigForm", viewModel);
        }

        /// <summary>
        /// POST method for create a new gig based on data in the form 
        /// </summary>


        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(GigsFormViewModel formViewModel)
        {
            // Something is not valid, reinitialize the form
            if (!ModelState.IsValid)
            {
                formViewModel.Genres = _unitOfWork.Genres.GetAllGenres();
                return View("GigForm", formViewModel);
            }
            // Everything is fine, create a new gig 
            var gig = new Gig()
            {
                ArtistId = User.Identity.GetUserId(),
                GenreId = formViewModel.GenreId,
                DateTime = formViewModel.GetDateTime(),
                Venue = formViewModel.Venue
            };
            // Add to the database and save the changes
            _unitOfWork.Gigs.Add(gig);

           _unitOfWork.Complete();

            return RedirectToAction("MyGigs", "Gigs");
        }

        /// <summary>
        /// Return all the gigs that current user is attending
        /// </summary>
        /// <returns></returns>
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            // Look for the gig on the database, override lazy loading for Artist and Genre as well

            var viewModel = new GigsDisplayViewModel()
            {
                DisplayingGigs = _unitOfWork.Gigs.GetGigsUserAttending(userId),
                ShowActions = User.Identity.IsAuthenticated,
                Header = "Attending",
                Attendances = _unitOfWork.Attendances.GetFutureAttendances(userId)
                    .ToLookup(g => g.GigId)
            };

            return View("Gigs", viewModel);
        }





        /// <summary>
        /// Similar to Create Action earlier
        /// </summary>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Update(GigsFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _unitOfWork.Genres.GetAllGenres();
                return View("GigForm", viewModel);
            }

            var gig = _unitOfWork.Gigs.GetGigWithAttendee(viewModel.Id);

            if (gig == null)
                return HttpNotFound();

            if (gig.ArtistId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            gig.Modify(viewModel.GetDateTime(), viewModel.Venue, viewModel.GenreId);



            _unitOfWork.Complete();
            return RedirectToAction("MyGigs", "Gigs");
        }

        /// <summary>
        /// Find and initialize the form for editing
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();

            var gig = _unitOfWork.Gigs.GetGigWithId(id);

            if (gig == null)
                return HttpNotFound();

            if (gig.ArtistId != userId)
                return new HttpUnauthorizedResult();

            // Set new values
            var viewModel = new GigsFormViewModel()
            {
                Heading = "Edit a Gig",
                Id = gig.Id,
                Genres = _unitOfWork.Genres.GetAllGenres(),
                Date = gig.DateTime.ToString("d MMM yyyy"),
                Time = gig.DateTime.ToString("HH:mm"),
                Venue = gig.Venue,
                GenreId = gig.GenreId
            };

            return View("GigForm", viewModel);
        }

        /// <summary>
        /// Return gigs that are hosted by current user, only those in the future and not be canceled
        /// </summary>
        /// <returns></returns>
        public ActionResult MyGigs()
        {
            var userId = User.Identity.GetUserId();

            var gigs = _unitOfWork.Gigs.GetUpcomingGigsByArtist(userId);
          

            var viewModel = new MyGigsViewModel()
            {
                MyGigs = gigs
            };

            return View(viewModel);
        }
        /// <summary>
        /// Search for a gig by a given query
        /// </summary>
        [HttpPost]
        public ActionResult Search(GigsDisplayViewModel viewModel)
        {
            return RedirectToAction("Index", "Home", new { query = viewModel.SearchTerm });
        }
        /// <summary>
        /// This is mark as AllowAnonymous because we want guest know about the detail about an Artist as well
        /// but guest will not see some details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var gig = _unitOfWork.Gigs.GetGigWithId(id);

            if (gig == null)
                return HttpNotFound();

            var viewModel = new GigDetailsViewModel() { Gig = gig };

            // This will be hidden from guest users
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                    
                viewModel.IsAttending = _unitOfWork.Attendances.GetAttendance(id, userId) != null;

                viewModel.IsFollowing = _unitOfWork.Followings.GetFollowing(gig.ArtistId, userId) != null;

            }
            return View("Details", viewModel);
        }
    }
}