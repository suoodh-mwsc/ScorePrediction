using System.ComponentModel.DataAnnotations;

namespace ScorePrediction.Web.Models.Dto.Tournament
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
        public Boolean ScorePrediction { get; set; }
    }
}
