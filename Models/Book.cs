using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookCatalogApi.Models;

[Table("Books")]
public class Book
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(80)]
    public string? Name { get; set; }
    [Required]
    [StringLength(80)]
    public string? Author { get; set; }
    [Required]
    public int  Year { get; set; }
    [Required]
    public string? Description { get; set; }
    public DateTime RegistrationDate { get; set; }
    public int CategoryId { get; set; }
    [JsonIgnore]
    public Category? Category { get; set; }
}