using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcGames.Models
{
    public class IdentityUserProfile : IdentityUser
    {
        [ProtectedPersonalData]
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }

        public int? ProfileImageId { get; set; }

        public virtual FileModel? ProfileImage { get; set; }

        [NotMapped]
        public bool HasProfileImage
        {
            get
            {
                return ProfileImageId != null;
            }
        }
    }
}
