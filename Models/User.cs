
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookCatalogApi.Models;

[Table("Users")]
public class User 
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(80)]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
    public bool IsAdmin { get; set; }
}