using PurpleRain2.Data;
using PurpleRain2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleRain2.Services
{
    public class OutfitService
    {
        private readonly Guid _userId;

        public OutfitService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateOutfit(int dayid, OutfitCreate model)
        {
            var entity =
                new Outfit()
                {

                    OutfitName = model.OutfitName,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Outfits.Add(entity);
                if (ctx.SaveChanges() == 1)
                {
                    var days =
                        ctx
                         .Days
                        .Single(e => e.DayID == dayid && e.OwnerID == _userId);

                    days.OutfitID = entity.OutfitID;
                    return ctx.SaveChanges() == 1;
                }
                return false;
            }
        }
        public OutfitDetails GetOutfitByID(int outfitid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Outfits
                        .Single(e => e.OutfitID == outfitid);
                return
                    new OutfitDetails
                    {
                        OutfitID = entity.OutfitID,
                        OutfitName = entity.OutfitName,
                        Top = entity.Top,
                        Bottom = entity.Bottom,
                    };
            }
        }
        public bool UpdateOutfit(int outfitid, OutfitEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Outfits
                        .Single(e => e.OutfitID == outfitid);
                entity.OutfitName = model.OutfitName;
                entity.Top = model.Top;
                entity.Bottom = model.Bottom;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteOutfit(int outfitid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Outfits
                        .Single(e => e.OutfitID == outfitid);
                var entity2 =
                   ctx
                   .Days
                   .Single(e => e.OutfitID == outfitid);
                entity2.OutfitID = null;
                ctx.Outfits.Remove(entity);
                return ctx.SaveChanges() == 2;
            }
        }
    }
}
