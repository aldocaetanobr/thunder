using System.ComponentModel.DataAnnotations;

namespace Models
{
    public abstract class BaseDbModel
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        [Required]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
