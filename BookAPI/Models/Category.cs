using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAPI;

public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(50, ErrorMessage = "Max 50 characters")]
    public string Name { get; set; }

    public virtual ICollection<BookCategory> BookCategories { get; set; }
}
