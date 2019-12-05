using Microsoft.AspNet.Identity;
using PurpleRain2.Models;
using PurpleRain2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PurpleRain2.WebAPI.Controllers
{
    public class OutfitController : Controller
    {
        //public IHttpActionResult GetAll()
        //{
        //    OutfitService outfitService = CreateOutfitService();
        //    var outfits = outfitService.GetOutfit();
        //    return Ok(days);
        //}

        public IHttpActionResult Get(int id)
        {
            OutfitService outfitService = CreateOutfitService();
            var outfit = outfitService.GetOutfitByID(id);
            return Ok(outfit);
        }

        public IHttpActionResult Post(OutfitCreate outfit)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateOutfitService();

            if (!service.CreateOutfit(outfit))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(OutfitEdit outfit)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateOutfitService();

            if (!service.UpdateOutfit(outfit))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateOutfitService();

            if (!service.DeleteOutfit(id))
                return InternalServerError();

            return Ok();
        }

        private OutfitService CreateOutfitService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var outfitService = new OutfitService(userId);
            return outfitService;
        }
    }
}
