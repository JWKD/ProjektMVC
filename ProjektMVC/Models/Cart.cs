using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Cart
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
}

public class CartItem
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("Cart")]
    public int CartId { get; set; }
    public Cart Cart { get; set; }

    [Required]
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
}
