using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)] // Max length for the category name
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
