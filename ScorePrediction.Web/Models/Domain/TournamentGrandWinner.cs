﻿using System.ComponentModel.DataAnnotations;

namespace FenClub.Models.Domain
{
    public class TournamentGrandWinner
    {
        [Key]
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }


        public string WinnerEmployeeId { get; set; }
        public string GrandWinnerTitle { get; set; }
        public DateTime PublishedOn { get; set; }


        public TournamentGrandPrize TournamentGrandPrizeId { get; set; }
        public Tournament TournamentId { get; set; }
    }
}