using System.ComponentModel.DataAnnotations;

namespace BookShelf.web.Models.Category;

public class category
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int DisplayOrder { get; set; }


}
