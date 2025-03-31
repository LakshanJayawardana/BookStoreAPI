using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreAPI.Models;

public class BookDetail
{
    [Key]
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(100)")]
    public string Title { get; set; } = "";
    [Column(TypeName = "nvarchar(100)")]
    public string Description { get; set; } = "";
    [Column(TypeName = "nvarchar(100)")]
    public string Author { get; set; } = "";
    [Column(TypeName = "nvarchar(100)")]
    public string Category { get; set; } = "";

}