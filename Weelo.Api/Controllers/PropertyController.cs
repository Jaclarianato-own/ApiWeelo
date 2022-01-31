using Weelo.Application.Services;
using Weelo.Domain;
using Weelo.DTO;
using Weelo.Infrastructure.Data.Contexts;
using Weelo.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Weelo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        //
        //Review:
        //  Initializing a propertyService.
        //Parameters:
        //Return:
        // return a property service.
        PropertyService CreateService()
        {
            PropertyContext db = new PropertyContext();
            PropertyRepository repo = new PropertyRepository(db);
            PropertyService servcie = new PropertyService(repo);

            return servcie;
        }

        // GET: api/<PropertyController>
        [HttpGet]
        public ActionResult Get()
        {
            var service = CreateService();

            return Ok(service.ListAll());
        }

        // GET api/<PropertyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PropertyController>
        [HttpPost]
        public ActionResult Post([FromBody] Property property)
        {
            var servicio = CreateService();

            try
            {
                servicio.Create(property);

                return Ok("Property successfully created.");
            }
            catch (Exception e)
            {
                return BadRequest($"ERROR: {e.Message}," +
                    $" DESCRIPTION: {e.InnerException.Message}");
                
            }
        }

        // POST api/<PropertyController>
        [HttpPost]
        [Route("UpdatePrice")]
        public ActionResult UpdatePrice([FromBody] Property property)
        {
            var servicio = CreateService();

            try
            {
                servicio.UpdatePrice(property);

                return Ok("Property's price successfully updated.");
            }
            catch (Exception e)
            {
                return BadRequest($"ERROR: {e.Message}," +
                    $" DESCRIPTION: {e.InnerException.Message}");

            }
        }

        // POST api/<PropertyController>
        [HttpPost]
        [Route("Update")]
        public ActionResult Update([FromBody] Property property)
        {
            var servicio = CreateService();

            try
            {
                servicio.Update(property);

                return Ok("Property's successfully updated.");
            }
            catch (Exception e)
            {
                return BadRequest($"ERROR: {e.Message}," +
                    $" DESCRIPTION: {e.InnerException.Message}");

            }
        }

        // POST api/<PropertyController>
        [HttpPost]
        [Route("ListWithFilters")]
        public ActionResult ListWithFilters([FromBody] FilterDto filter)
        {
            var servicio = CreateService();

            try
            {
                var result = servicio.ListWithFilters(filter);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest($"ERROR: {e.Message}," +
                    $" DESCRIPTION: {e.InnerException.Message}");

            }
        }

        // PUT api/<PropertyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PropertyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
