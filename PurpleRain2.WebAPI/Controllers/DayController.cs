using Microsoft.AspNet.Identity;
using PurpleRain2.Models;
using PurpleRain2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AuthorizeAttribute = System.Web.Http.AuthorizeAttribute;

namespace PurpleRain2.WebAPI.Controllers
{
    [Authorize]
    public class DayController : Controller
    {
        public IHttpActionResult GetAll()
        {
            DayService dayService = CreateDayService();
            var days = dayService.GetDay();
            return Ok(days);
        }

        public IHttpActionResult Get(int id)
        {
            DayService dayService = CreateDayService();
            var day = dayService.GetDayById(id);
            return Ok(day);
        }

        public IHttpActionResult Post(DayCreate day)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDayService();

            if (!service.CreateDay(day))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(DayEdit day)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDayService();

            if (!service.UpdateDay(day))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateDayService();

            if (!service.Deleteday(id))
                return InternalServerError();

            return Ok();
        }

        private DayService CreateDayService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var dayService = new DayService(userId);
            return dayService;
        }
    }
}