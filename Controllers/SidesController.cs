using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BurgerShack.Models;
using BurgerShack.Services;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SidesController : ControllerBase
    {
        private readonly SidesService _ss;

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Side>> Get()
        {
            return _ss.GetSides();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Side> Post([FromBody] Side sideData)
        {
            try
            {
                Side mySide = _ss.AddSide(sideData);
                return Ok(mySide);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message); //code snippet
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Side> Put(string id, [FromBody] Side sideData)
        {
            try
            {
                sideData.Id = id;
                var burger = _ss.EditSide(sideData);
                return Ok(sideData);
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Side> Delete(string id)
        {
            try
            {
                var side = _ss.DeleteSide(id);
                return Ok(side);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public SidesController(SidesService ss)
        {
            _ss = ss;
        }
    }
}