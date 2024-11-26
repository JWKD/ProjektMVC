using System.ComponentModel.DataAnnotations;

public class VisitCounter
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int VisitCount { get; set; }
}
