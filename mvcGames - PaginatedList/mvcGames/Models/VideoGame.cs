using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcGames.Models
{
    public class VideoGame
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Game Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release Year")]
        public DateTime? ReleaseYear { get; set; }

        [Required]
        [Range(1, 5)]
        [Display(Name = "Personal Rating")]
        public int PersonalRating { get; set; }

        [Required]
        [Display(Name = "Platform")]
        public int PlatformId { get; set; }

        public virtual Platform? Platform { get; set; }

        public int? ImageId { get; set; }

        public virtual FileModel? Image { get; set; }

        [NotMapped]
        public SelectList? AvailablePlatforms { get; set; }

        [NotMapped]
        public bool ShowModifyLinks { get; set; }

        [NotMapped]
        public bool HasImage
        {
            get
            {
                return ImageId != null;
            }
        }
    }
}
