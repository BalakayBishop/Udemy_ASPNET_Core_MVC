using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class OrderItem
    {
        [Key]
        public int ID { get; set; }

        public int Amount { get; set; }

        public double Price { get; set; }

        // Ref to Movie
        public int Movie_ID { get; set; }
        [ForeignKey("Movie_ID")]
        public MovieModel Movie { get; set; }

        // Ref to Order
        public int Order_ID { get; set; }
        [ForeignKey("Order_ID")]
        public Order Order { get; set; }
    }
}
