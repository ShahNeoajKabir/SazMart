namespace SazMart.DAL.ModelClass.Entities
{
    public class ProductPhoto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public Product AppUser { get; set; }

        public int ProductId { get; set; }
    }
}