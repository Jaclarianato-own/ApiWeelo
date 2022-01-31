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
    public class PropertyTraceController : ControllerBase
    {
        //
        //Review:
        //  Initializing a propertyTraceService.
        //Parameters:
        //Return:
        // return a propertyTracde service.
        PropertyTraceService CreateService()
        {
            PropertyContext db = new PropertyContext();
            PropertyTraceRepository repo = new PropertyTraceRepository(db);
            PropertyTraceService servcie = new PropertyTraceService(repo);

            return servcie;
        }

        // GET: api/<PropertyTraceController>
        [HttpGet]
        public ActionResult Get()
        {
            var service = CreateService();

            return Ok(service.ListAll());
        }

        // GET api/<PropertyTraceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PropertyTraceController>
        [HttpPost]
        public ActionResult Post([FromBody] PropertyTrace propertyTrace)
        {
            var servicio = CreateService();

            try
            {
                servicio.Create(propertyTrace);

                return Ok("Property trace successfully created.");
            }
            catch (Exception e)
            {
                return BadRequest($"ERROR: {e.Message}," +
                    $" DESCRIPTION: {e.InnerException.Message}");

            }
        }

        // PUT api/<PropertyTraceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PropertyTraceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
