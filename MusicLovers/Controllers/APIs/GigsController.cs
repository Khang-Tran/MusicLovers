using System.Web.Http;

using Microsoft.AspNet.Identity;
using MusicLovers.Core.Contracts;

namespace MusicLovers.Controllers.APIs
{
    [Authorize]
    public class GigsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public GigsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// An Api method for DELETE request for cancel a gig, based on current log in user and gigId they want to cancel
        /// </summary>
        /// <returns>
        /// if either the gig is not found in the database or it already been canceled, return a 404
        /// otherwise create a notification to users that follow that gig and save it to the database
        /// </returns>
        ///

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();

            var gig = _unitOfWork.Gigs.GetGigWithId(id);

            // This gig is not exist in the database
            if (gig == null)
                return NotFound();

            // Make sure the same user that log in
            if (gig.ArtistId != userId)
                return Unauthorized();


            // It already been canceled
            if (gig.IsCancel)
                return NotFound();

            // Cancel it
            gig.Cancel();

            _unitOfWork.Complete();

            // Every is fine so far, return a 200 code
            return Ok();
        }
    }
}
