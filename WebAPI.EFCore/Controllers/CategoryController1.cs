using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Get()
        {
            // Not Found
            //return NotFound();
            //return BadRequest();
            return Ok(_context.categories);
        }

        // GET api/<CategoryController1>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_context.categories.FirstOrDefault(x=>x.Id==id));
        }

        // POST api/<CategoryController1>
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            _context.categories.Add(category);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<CategoryController1>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            var CategoryFromDb = _context.categories.FirstOrDefault(x => x.Id == id);
            CategoryFromDb.Name = category.Name;
            CategoryFromDb.CategoryOrder = category.CategoryOrder;
            _context.categories.Update(CategoryFromDb);
            _context.SaveChanges(); 
            return Ok("Category Updated..!");
        }

        // DELETE api/<CategoryController1>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var CategoryFromDb = _context.categories.Find(id);
            _context.categories.Remove(CategoryFromDb);
            _context.SaveChanges();
            return Ok("Category Deleted..!");
        }
    }
}
