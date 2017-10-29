using System.Web.Http;
using Microsoft.AspNet.Identity;
using MusicLovers.Core.Contracts;
using MusicLovers.Core.DTOs;
using MusicLovers.Core.Models.Entities;


namespace MusicLovers.Controllers.APIs
{
    /// <summary>
    /// This class is marked as Authorized because we only want those who have account to have access to our data
    /// </summary>
    [Authorize]
    public class AttendancesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public AttendancesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Api method for POST request for adding new attendance to the database, based on current log in user and gig they want to attend
        /// </summary>
        /// <returns>
        /// if that userId and or gigId already in the database, return a bad request, otherwise create a new attendance and add it to the database
        /// </returns>
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            // Get the log in userId
            var userId = User.Identity.GetUserId();
            // Check for existence
            var exists = _unitOfWork.Attendances.IsExisted(dto.GigId, userId);
            if (exists)
                return BadRequest("The attendance already existed");
            // Now the item is not exist.. create a new attendance
            var attendance = new Attendance()
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };
            // Every is fine, start adding
            _unitOfWork.Attendances.Add(attendance);
            // Save changes
            _unitOfWork.Complete();

            return Ok("Added gig with id " + dto.GigId );
        }
        /// <summary>
        /// Api method for delete an attendance basted on current log in user and gig id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var userId = User.Identity.GetUserId();
            // Find it in the database
            var attendance = _unitOfWork.Attendances.GetAttendance(id, userId);
            // If it is null, then return 404
            if (attendance == null)
                return NotFound();
            // Remove and save changes  
            _unitOfWork.Attendances.Remove(attendance);

            _unitOfWork.Complete();

            return Ok(id);
        }

    }
}
