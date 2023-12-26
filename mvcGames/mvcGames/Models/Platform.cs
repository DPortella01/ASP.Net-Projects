using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcGames.Models
{
    public class Platform
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Platform Name")]
        public string Name { get; set; }

        public virtual ICollection<VideoGame>? VideoGames { get; set; }

        [NotMapped]
        public bool ShowModifyLinks { get; set; }
    }
}
