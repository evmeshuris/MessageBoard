using System;
using System.ComponentModel.DataAnnotations;
namespace MessageBoard.Models
{
  public class Message
  {
    public int MessageId { get; set; }
    [Required]
    [StringLength(20)]
    public string Author { get; set; }
    [Required]
    public string Group { get; set; }
    [Required]
    [StringLength(255)]
    public string Body { get; set; }
    [Required]
    public DateTime Date { get; set; }
  }
}