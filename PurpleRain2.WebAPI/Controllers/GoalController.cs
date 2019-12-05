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
    public class GoalController : Controller
    {
        //public IHttpActionResult GetAll()
        //{
        //    GoalService goalService = CreateGoalService();
        //    var goals = goalService.GetGoal();
        //    return Ok(goals);
        //}

        public IHttpActionResult Get(int id)
        {
            GoalService goalService = CreateGoalService();
            var goal = goalService.GetGoalByID(id);
            return Ok(goal);
        }

        public IHttpActionResult Post(GoalCreate goal)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGoalService();

            if (!service.CreateGoal(goal))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(GoalEdit goal)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGoalService();

            if (!service.UpdatGoal(goal))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateGoalService();

            if (!service.DeleteGoal(id))
                return InternalServerError();

            return Ok();
        }

        private GoalService CreateGoalService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var goalService = new GoalService(userId);
            return goalService;
        }
    }
}