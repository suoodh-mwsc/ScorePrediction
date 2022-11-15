using System.ComponentModel.DataAnnotations;

namespace ScorePrediction.Web.Models.Dto
{
    public class CreateTournamentDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime StartOn { get; set; }

        [Required]
        public DateTime EndOn { get; set; }

        [Required]
        public bool ScorePrediction { get; set; }
    }
}
