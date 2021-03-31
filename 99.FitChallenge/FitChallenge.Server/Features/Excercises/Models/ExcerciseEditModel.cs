using System.ComponentModel.DataAnnotations;

namespace FitChallenge.Server.Features.Excercises.Models
{
    public class ExcerciseEditModel : ExcerciseCreateModel
    {
        [Required]
        public int Id { get; set; }
    }
}
