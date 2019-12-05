using PurpleRain2.Data;
using PurpleRain2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleRain2.Services
{
    public class DayService
    {
        private readonly Guid _userId;

        public DayService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateDay(DayCreate model)
        {
            var entity =
                new Day()
                {
                    OwnerID = _userId,
                    DayName = model.DayName,
                    Date = model.Date
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Days.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<DayListItem> GetDay()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Days
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new DayListItem
                                {
                                    DayID = e.DayID,
                                    DayName = e.DayName,
                                }
                        );

                return query.ToArray();
            }
        }
        public DayDetails GetDayById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Days
                        .Single(e => e.DayID == id && e.OwnerID == _userId);
                return
                    new DayDetails
                    {
                        DayID = entity.DayID,
                        DayName = entity.DayName,
                        Date = entity.Date,
                    };
            }
        }
        public bool UpdateDay(DayEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Days
                        .Single(e => e.DayID == model.DayID && e.OwnerID == _userId);

                entity.DayName = model.DayName;
                entity.Date = model.Date;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool Deleteday(int dayId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Days
                        .Single(e => e.DayID == dayId && e.OwnerID == _userId);

                ctx.Days.Remove(entity);

                 if (entity.Outfit != null && entity.Goal != null)
                {
                    ctx.Outfits.Remove(entity.Outfit);
                    ctx.Goals.Remove(entity.Goal);
                    ctx.Days.Remove(entity);
                    return ctx.SaveChanges() == 3;
                }
                else if (entity.Outfit != null)
                {
                    ctx.Outfits.Remove(entity.Outfit);
                    ctx.Days.Remove(entity);
                    return ctx.SaveChanges() == 2;
                }
                else if (entity.Goal != null)
                {
                    ctx.Goals.Remove(entity.Goal);
                    ctx.Days.Remove(entity);
                    return ctx.SaveChanges() == 2;
                }
                else
                {
                    ctx.Days.Remove(entity);
                    return ctx.SaveChanges() == 1;
                }
            }
        }
    }
}
