using System.ComponentModel.DataAnnotations.Schema;

namespace SazMart.DAL.ModelClass.Entities
{
    public class BrandLogo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
    }
}
