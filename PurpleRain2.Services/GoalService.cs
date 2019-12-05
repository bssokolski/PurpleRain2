using PurpleRain2.Data;
using PurpleRain2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleRain2.Services
{
    public class GoalService
    {
        private readonly Guid _userId;

        public GoalService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateGoal(int dayid, GoalCreate model)
        {
            var entity =
                new Data.Goal()
                {
                    GoalName = model.GoalName,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Goals.Add(entity);
                if (ctx.SaveChanges() == 1)
                {
                    var days =
                        ctx
                         .Days
                        .Single(e => e.DayID == dayid && e.OwnerID == _userId);

                    days.GoalID = entity.GoalID;
                    return ctx.SaveChanges() == 1;
                }
                return false;
            }
        }
        public GoalDetails GetGoalByID(int goalid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Goals
                        .Single(e => e.GoalID == goalid);
                return
                    new GoalDetails
                    {
                        GoalID = entity.GoalID,
                        GoalName = entity.GoalName,
                        GoalDescription =entity.GoalDescription
                    };
            }
        }
        public bool UpdatGoal(int actionid, GoalEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Goals
                        .Single(e => e.GoalID == actionid);
                entity.GoalName = model.GoalName;
                entity.GoalDescription = model.GoalDescription;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteGoal(int goalid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Goals
                        .Single(e => e.GoalID == goalid);
                var entity2 =
                   ctx
                   .Days
                   .Single(e => e.GoalID == goalid);
                entity2.GoalID = null;
                ctx.Goals.Remove(entity);
                return ctx.SaveChanges() == 2;
            }
        }
    }
}
