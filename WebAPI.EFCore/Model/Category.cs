namespace WebAPI.EFCore.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryOrder { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
