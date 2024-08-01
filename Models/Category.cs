using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BookCatalogApi.Models;

public class Category 
{
    public Category()
    {
        Books = new Collection<Book>();
    }
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(80)]
    public string? Name { get; set; }
    [Required]
    [StringLength(300)]
    public string? ImageUrl { get; set; }
    public ICollection<Book>? Books { get; set; }
}
