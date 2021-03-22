using System.ComponentModel.DataAnnotations;
using FitChallenge.Server.Data.Models.Enums;

using static FitChallenge.Server.Data.DataConstants.User;

namespace FitChallenge.Server.Data.Models
{
    public class Profile
    {
        public int Id { get; set; }

        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [Url]
        public string MainPhotoUrl { get; set; }

        [Url]
        public string WebSite { get; set; }

        public Gender Gender { get; set; }

        public FitLevel FitLevel { get; set; }

        [Range(MinWeight, MaxWeight)]
        public int Weight { get; set; }

        [Range(MinHeight, MaxHeight)]
        public int Height { get; set; }

        public bool IsPrivate { get; set; }

        [MaxLength(MaxBiographyLentgh)]
        public string Biography { get; set; }

        public User User { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
