using Entities.Common;

namespace Entities
{
    public class Magazine:BaseEntity
    {
        public string Name { get; set; }
        public int PageCount { get; set; }
        public int Year { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
