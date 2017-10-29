using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MusicLovers.Core.Contracts;
using MusicLovers.Core.Models;
using MusicLovers.Core.ViewModel;
using MusicLovers.Persistence;

namespace MusicLovers.Controllers.MVCs
{
    [Authorize]
    public class FolloweesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public FolloweesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all the Artist that current log in user is following
        /// </summary>
        /// <returns>
        /// A list of Artist that user is following
        /// </returns>
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            // Get all the followees
            var followees = _unitOfWork.Followings.GetAllFollowee(userId);

            // Create viewModel
            var viewModel = new FolloweeViewModel()
            {
                Followees = followees
            };

            return View(viewModel);
        }
    }
}