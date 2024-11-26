using System.ComponentModel.DataAnnotations;

public class Customer
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50)]
    public string LastName { get; set; }

    [Required]
    [EmailAddress] // Validate email format
    public string Email { get; set; }

    [Required]
    public string Address { get; set; }

    public bool ShowNetPrices { get; set; }

    [Required]
    [StringLength(50)]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; } // Hashed password

}
