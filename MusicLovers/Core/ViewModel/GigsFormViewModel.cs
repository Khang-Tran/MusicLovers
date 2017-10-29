using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;
using MusicLovers.Controllers.MVCs;
using MusicLovers.Core.Models.CustomValidations;
using MusicLovers.Core.Models.Entities;

namespace MusicLovers.Core.ViewModel
{
    public class GigsFormViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Venue { get; set; }
        [Required]
        [DateValidation]
        public string Date { get; set; }
        [Required]
        [TimeValidation]
        public string Time { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<GigsController, ActionResult>> update = (c => c.Update(this));
                Expression<Func<GigsController, ActionResult>> create = (c => c.Create(this));
                var action = Id != 0 ? update : create;
                return ((MethodCallExpression) action.Body).Method.Name;
            }
        }

        public DateTime GetDateTime()
        {
            return DateTime.Parse($"{Date} {Time}");
        }
    }
}
