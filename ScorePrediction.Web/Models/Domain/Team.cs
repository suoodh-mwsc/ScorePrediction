using ScorePrediction.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FenClub.Models.Domain
{
    public class Team
    {
        [Key]
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }


        [Required, DisplayName("Name"), MaxLength(50)]
        public string Name { get; set; }
        public string Logo { get; set; }


        [ForeignKey("Tournament")]
        Guid TournamentId { get; set; }
        public Tournament Tournament { get; set; }
    }
}
