using System.ComponentModel.DataAnnotations;

namespace mvcGames.Models
{
    public class FileModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? FileName { get; set; }

        [Required]
        public string? ContentType { get; set; }

        [Required]
        public byte[]? Content { get; set; }
    }
}
