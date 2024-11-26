using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OrderItem
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("Order")]
    public int OrderId { get; set; }
    public Order Order { get; set; }

    [Required]
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    [Required]
    [Range(1, int.MaxValue)] // Ensure quantity is at least 1
    public int Quantity { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal UnitPriceNet { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal UnitPriceGross { get; set; }
}
