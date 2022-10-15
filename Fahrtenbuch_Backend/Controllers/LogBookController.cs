using System;
using Fahrtenbuch_Backend.DTO;
using Fahrtenbuch_Backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fahrtenbuch_Backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LogBookController : ControllerBase
    {
        List<Journey> ListofJourneys = new List<Journey>();
        //LOCAL TESTING


        private readonly LogBookDBContext _context;
        public LogBookController(LogBookDBContext context)
        {
            _context = context;
        }
        // GET: api/Logbooks
        [HttpGet("journeys")]
        public async Task<ActionResult<Logbook>> GetLogbooks()
        {
            //return Ok(await _context.Journey.ToListAsync());

            Logbook logbook = new Logbook(await _context.Journey.ToListAsync());
            return Ok(logbook);

        }

        [HttpGet("journeyslocal")]
        public List<Journey> GetLogbooksLocal()
        {
            return ListofJourneys;

        }
        [HttpPost("journeys")]
        public async Task<ActionResult> PostJourney([FromBody] JourneyDTO journeyDTO)
        {
            if (journeyDTO == null || !ModelState.IsValid) // if not valid return Bad Request
            {
                return BadRequest();
            }
            Journey newJourney = new Journey(journeyDTO.Driver,journeyDTO.Description,journeyDTO.Start,journeyDTO.End,journeyDTO.Distance);
            
            await _context.Journey.AddAsync(newJourney);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost ("journeyslocal")]
        public bool PostJourneyLocal([FromBody] JourneyDTO journeyDTO)
        {
            if (journeyDTO == null || !ModelState.IsValid)
            {
                return false;
            }

            Journey newJourney = new Journey(journeyDTO.Driver, journeyDTO.Description, journeyDTO.Start, journeyDTO.End, journeyDTO.Distance);
            ListofJourneys.Add(newJourney);
            return true;
        }

    }
}

