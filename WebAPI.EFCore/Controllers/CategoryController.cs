using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.EFCore.Model;

namespace WebAPI.EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public static List<Category> listOfCategories = new List<Category>
        {
            new Category{Id = 1, Name = "LG", CategoryOrder = 2},
            new Category{Id = 2, Name = "HTC", CategoryOrder = 4},
            new Category{Id = 3, Name = "Samsung", CategoryOrder = 2},
            new Category{Id = 4, Name = "Nokia", CategoryOrder = 4},
            new Category{Id = 5, Name = "Vivo", CategoryOrder = 2},
            new Category{Id = 6, Name = "Redme", CategoryOrder = 4},
        };
        [HttpGet]   // Reading the Code
        public IEnumerable<Category> Get()
        {
            return listOfCategories;
        }
        [HttpPost]  // Creating the Code
        public void Post(Category category)
        {
            listOfCategories.Add(category);
        }
        [HttpPut("{id}")]   // Updating the Code
        public void Put(int id, Category category)
        {
            listOfCategories[id] = category;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            listOfCategories.RemoveAt(id);
        }
    }
}