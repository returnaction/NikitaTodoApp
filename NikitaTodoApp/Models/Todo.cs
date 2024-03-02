using System.ComponentModel.DataAnnotations;

namespace NikitaTodoApp.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Title { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}
