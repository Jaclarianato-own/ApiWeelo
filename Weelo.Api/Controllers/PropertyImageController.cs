using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weelo.Application.Services;
using Weelo.Domain;
using Weelo.Infrastructure.Data.Contexts;
using Weelo.Infrastructure.Data.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Weelo.PropertyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyImageController : ControllerBase
    {
        //
        //Review:
        //  Initializing a PropertyImageService.
        //Parameters:
        //Return:
        // return a ImageProperty service.
        PropertyImageService CreateService()
        {
            PropertyContext db = new PropertyContext();
            PropertyImageRepository repo = new PropertyImageRepository(db);
            PropertyImageService servcie = new PropertyImageService(repo);

            return servcie;
        }

        // GET: api/<PropertyImageController>
        [HttpGet]
        public ActionResult Get()
        {
            var service = CreateService();

            return Ok(service.ListAll());
        }

        // GET api/<PropertyImageController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PropertyImageController>
        [HttpPost]
        public ActionResult Post([FromBody] PropertyImage propertyImage)
        {
            var servicio = CreateService();

            try
            {
                servicio.Create(propertyImage);

                return Ok("Property image successfully created.");
            }
            catch (Exception e)
            {
                return BadRequest($"ERROR: {e.Message}," +
                    $" DESCRIPTION: {e.InnerException.Message}");

            }
        }

        // PUT api/<PropertyImageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PropertyImageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
