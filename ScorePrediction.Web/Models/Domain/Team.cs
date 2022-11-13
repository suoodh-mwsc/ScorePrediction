using System.ComponentModel.DataAnnotations;

namespace FenClub.Models.Domain
{
    public class Team
    {
        [Key]
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }


        public string Name { get; set; }
        public string Logo { get; set; }


        public Guid TournamentId { get; set; }
        public Tournament Tournament { get; set; }
    }
}
