using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ContactForm
{
    [Key]
    public int Id { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Message { get; set; }

    [ForeignKey("Product")]
    public int? ProductId { get; set; } // Optional reference to a product
    public Product Product { get; set; }
}
