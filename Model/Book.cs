using System.ComponentModel.DataAnnotations;

namespace BookApi.Models;
public class Book
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string? Name { get; set; }

    [Required]
    [Range(15, 1000)]
    public int Pages { get; set; }

    [Required]
    [MaxLength(255)]
    public string? Author { get; set; }
}