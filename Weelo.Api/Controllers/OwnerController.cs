using Weelo.Application.Services;
using Weelo.Infrastructure.Data.Contexts;
using Weelo.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weelo.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Weelo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        //
        //Review:
        //  Initializing a owner service.
        //Parameters:
        //Return:
        // return a owner service.
        OwnerService CreateService()
        {
            PropertyContext db = new PropertyContext();
            OwnerRepository repo = new OwnerRepository(db);
            OwnerService servcie = new OwnerService(repo);

            return servcie;
        }

        // GET: api/<OwnerController>
        [HttpGet]
        public ActionResult Get()
        {
            var service = CreateService();

            return Ok(service.ListAll());
        }

        // GET api/<OwnerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OwnerController>
        [HttpPost]
        public ActionResult Post([FromBody] Owner owner)
        {
            var servicio = CreateService();

            servicio.Create(owner);

            return Ok("Owner successfully created.");
        }

        // PUT api/<OwnerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OwnerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
