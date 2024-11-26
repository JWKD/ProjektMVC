using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class File
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(200)] // Max length for file name
    public string Name { get; set; }

    [Required]
    public string Path { get; set; } // Path to the file

    public string Description { get; set; } // Optional description

    [Required]
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product Product { get; set; }
}
