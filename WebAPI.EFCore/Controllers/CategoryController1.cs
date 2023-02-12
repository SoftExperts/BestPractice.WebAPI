using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.EFCore.Data;
using WebAPI.EFCore.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
/*  Status Code
    1xx : Informational
    2xx : Successfuly
    3xx : Redirection
    4xx : Client Error
    5xx : Server Error
 */
namespace WebAPI.EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // This Method is a Permanent Storing data in SQL.
    public class CategoryController1 : ControllerBase
    {
        // GET: api/<CategoryController1>
        private ApplicationDbContext _context;

        public CategoryController1(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        //// Task<> task of type is a some return values.
        ///  Task is a no return values.
        public async Task<IActionResult> Get()        
        {
            // Not Found
            //return NotFound();
            //return BadRequest();
            return Ok(await _context.categories.ToListAsync());
        }

        // GET api/<CategoryController1>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _context.categories.FirstOrDefaultAsync(x=>x.Id==id));
        }

        // POST api/<CategoryController1>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            await _context.categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<CategoryController1>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Category category)
        {
            var CategoryFromDb = await _context.categories.FirstOrDefaultAsync(x => x.Id == id);
            // Using for Exaception Handling
            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            else
            {
                CategoryFromDb.Name = category.Name;
                CategoryFromDb.CategoryOrder = category.CategoryOrder;
                _context.categories.Update(CategoryFromDb);
                await _context.SaveChangesAsync(); 
                return Ok("Category Updated..!");
            }
        }

        // DELETE api/<CategoryController1>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var CategoryFromDb = await _context.categories.FindAsync(id);
            // Using for Exaception Handling
            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            else
            {
                _context.categories.Remove(CategoryFromDb);
                await _context.SaveChangesAsync();
                return Ok("Category Deleted..!");
            }
        }
    }
}
