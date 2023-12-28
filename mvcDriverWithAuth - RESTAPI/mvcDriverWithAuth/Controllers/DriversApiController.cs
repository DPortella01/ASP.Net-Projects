using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvcDriverWithAuth.Data;
using mvcDriverWithAuth.Models;
using mvcShortTermRentals.Data;
using mvcShortTermRentals.Models;

namespace mvcDriverWithAuth.Controllers
{
    [Route("api/Drivers")]
    [ApiController]
    public class DriversApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DriversApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: api/Drivers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Driver>>> GetRentalProperties()
        {
            if (_context.Drivers == null)
            {
                return NotFound();
            }
            return await _context.Drivers.ToListAsync();
        }


        //GET: api/Drivers/Page/1/Count/10
        [HttpGet("Page/{pageNumber}/Count/{pageSize}")]
        public async Task<ActionResult<PagedDTO<Driver>>> GetPaged(
            int pageNumber, int pageSize)
        {
            if (_context.Drivers == null)
            {
                return NotFound();
            }

            var result = await _context.Drivers
                .ToPagedDTOAsync(pageNumber, pageSize);

            return result;
        }


        //GET: /api/RentalProperties/7
        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> GetRentalProperty(int id)
        {
            if (_context.Drivers == null)
            {
                return NotFound();
            }

            var rentalProperty = await _context.Drivers.FindAsync(id);

            if (rentalProperty == null)
            {
                return NotFound();
            }

            return rentalProperty;
        }

    }
}
