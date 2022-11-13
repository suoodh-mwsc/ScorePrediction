﻿using System.ComponentModel.DataAnnotations;

namespace FenClub.Models.Domain
{
    public class TournamentGrandPrize
    {
        [Key]
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }


        public string Title { get; set; }
        public string Description { get; set; }


        public Tournament TournamentId { get; set; }
        public Match MatchId { get; set; }
    }
}
