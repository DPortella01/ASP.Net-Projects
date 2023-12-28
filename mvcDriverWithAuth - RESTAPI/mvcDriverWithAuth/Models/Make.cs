using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace mvcDriverWithAuth.Models
{
    public class Make
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Make Name")]
        public string MakeName { get; set; }

        /// <summary>
        /// ICollection<Driver>?is used to create a collection of Travelers.
        /// </summary>
        public virtual ICollection<Driver>? Drivers { get; set; }

        /// <summary>
        /// Thw ShowModifyLinks property is used to determine if the user is authenticated, then the user can modify the data.
        /// </summary>
        [NotMapped]
        public bool ShowModifyLinks { get; set; }
    }
}
