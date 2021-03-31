using System.ComponentModel.DataAnnotations;
using FitChallenge.Server.Data.Models.Enums;

namespace FitChallenge.Server.Features.Excercises.Models
{
    public class ExcerciseCreateModel
    {

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string ShortDescription { get; set; }

        [Url]
        public string Url { get; set; }

        [Required]
        public ExcerciseType ExcerciseType { get; set; }

        [Required]
        public ExcerciseDifficulty ExcerciseDifficulty { get; set; }
    }
}
