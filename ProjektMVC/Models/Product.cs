using ProjektMVC.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)] // Max length for the product name
    public string Name { get; set; }

    [Required]
    public string Description { get; set; } // HTML content allowed


    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    [Required]
    public string Image { get; set; } // Path to large image

    [Required]
    [Range(0, double.MaxValue)] // Ensure price is non-negative
    public decimal NetPrice { get; set; }

    [Required]
    [Range(0, 100)] // VAT rate as a percentage
    public decimal VATRate { get; set; }


}
