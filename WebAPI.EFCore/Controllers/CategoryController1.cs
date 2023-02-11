using Microsoft.AspNetCore.Mvc;
using WebAPI.EFCore.Data;
using WebAPI.EFCore.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public IEnumerable<Category> Get()
        {
            return _context.categories;
        }

        // GET api/<CategoryController1>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _context.categories.FirstOrDefault(x=>x.Id==id);
        }

        // POST api/<CategoryController1>
        [HttpPost]
        public void Post([FromBody] Category category)
        {
            _context.categories.Add(category);
            _context.SaveChanges();
        }

        // PUT api/<CategoryController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Category category)
        {
            var CategoryFromDb = _context.categories.Find(id);
            _context.categories.Update(CategoryFromDb);
            _context.SaveChanges(); 
        }

        // DELETE api/<CategoryController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var CategoryFromDb = _context.categories.Find(id);
            _context.categories.Remove(CategoryFromDb);
            _context.SaveChanges();
        }
    }
}
