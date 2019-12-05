using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
<<<<<<< HEAD

namespace PurpleRain2.WebAPI.Controllers
{
    public class GoalController : ApiController
    {
=======
using System.Net.Http;

namespace PurpleRain2.WebAPI.Controllers
{
    [Authorize]
    public class GoalController : ApiController
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

        public IHttpActionResult Post(int dayID,GoalCreate goal)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGoalService();

            if (!service.CreateGoal(dayID, goal))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(int actionId,GoalEdit goal)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGoalService();

            if (!service.UpdatGoal(actionId, goal))
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
>>>>>>> cf8933d51ca2a27c5a43f71dad2bbb1d41c39cf0
    }
}
