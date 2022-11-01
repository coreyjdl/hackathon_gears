using GearsMock.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace GearsMock.Controllers
{
    public class GearsController : ApiController
    {
        [HttpGet]
        public string Index()
        {
            return "Hello, World!";
        }

        [HttpPost]
        public IHttpActionResult CreateGearsRequestDraft(GearsRequest gearsRequest)
        {
            if(ModelState.IsValid)
            {
                return Ok(gearsRequest);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}