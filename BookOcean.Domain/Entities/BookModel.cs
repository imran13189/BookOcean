
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookOcean.Domain
{
    
    [MetadataType(typeof(BookModel))]
    public partial class Book
    {
        
        public int CountOrders { get; set; }
    }

    public class BookModel
    {
        [Required]
        public string BookName { get; set; }
        [Required]
        public string Publication { get; set; }
        [Required]
        public string Edition { get; set; }

        public int CountOrders { get; set; }

        //...
    }
}
