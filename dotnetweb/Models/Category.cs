using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace dotnetweb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string User { get; set; }
        [DisplayName("Display Order")]
        [Range(1,1000,ErrorMessage = "Display Order must be between 1 and 1000.")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
