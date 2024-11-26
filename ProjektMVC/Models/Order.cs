using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Order
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

    [Required]
    public DateTime OrderDate { get; set; }


    [Required]
    [StringLength(50)]
    public string PaymentMethod { get; set; }

    [Required]
    [StringLength(50)]
    public string DeliveryMethod { get; set; }
}
