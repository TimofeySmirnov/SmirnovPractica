using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationFindWorker.Models;
namespace WebApplicationFindWorker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly FindWorkerContext _context;

        public OfferController(FindWorkerContext context)
        {
            _context = context;
        }
        // GET: api/offers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Offer>>> GetAll()
        {
            return await _context.Offers.ToListAsync();
        }

        // GET: api/offer/{id}
        [HttpGet("{Id}")]
        public async Task<ActionResult<Offer>> GetById(int Id)
        {
            var offers = await _context.Offers.FindAsync(Id);
            if (offers is null)
                return NotFound();

            return offers;
        }

        // POST: api/games
        [HttpPost]
        public async Task<IActionResult> Create(Offer offer)
        {
            try
            {
                _context.Offers.Add(offer);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { Id = offer.Id }, offer);
            }
            catch (DbUpdateException)
            {
                // Обработка исключения
                return BadRequest("Ошибка при создании объявления.");
            }
        }

        // PUT: api/offers/{id}
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutOffer(int Id, Offer offer)
        {
            if (Id != offer.Id)
            {
                return BadRequest();
            }

            _context.Entry(offer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfferExists(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool OfferExists(int Id)
        {
            return _context.Offers.Any(e => e.Id == Id);
        }

        // DELETE: api/offer/{id}
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteOfffer(int Id)
        {
            var offer = await _context.Offers.FindAsync(Id);
            if (offer == null)
            {
                return NotFound();
            }

            _context.Offers.Remove(offer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
  
        
    }
}

