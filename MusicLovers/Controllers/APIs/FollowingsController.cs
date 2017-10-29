using System.Web.Http;
using Microsoft.AspNet.Identity;
using MusicLovers.Core.Contracts;
using MusicLovers.Core.DTOs;
using MusicLovers.Core.Models.Entities;

namespace MusicLovers.Controllers.APIs
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public FollowingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Similar to Attend Action in AttendancesController
        ///  Api for POST request for adding a follow in the database, based on current log in user and Artist they follow
        /// </summary>
        /// <returns>
        /// Bad request if current user already followed that Artist, otherwise adding it to the database
        /// </returns>

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            var exists = _unitOfWork.Followings.IsExist(userId, dto.FolloweeId);

            if (exists)
                return BadRequest("Already exists");

            var follow = new Following()
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };

            _unitOfWork.Followings.Add(follow);

            _unitOfWork.Complete();

            return Ok("Follow successfully");
        }
        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            var userId = User.Identity.GetUserId();
            var following = _unitOfWork.Followings.GetFollowing(id, userId);
            if (following == null)
                return NotFound();

            _unitOfWork.Followings.Remove(following);

            _unitOfWork.Complete();
            return Ok(id);
        }
    }
}
