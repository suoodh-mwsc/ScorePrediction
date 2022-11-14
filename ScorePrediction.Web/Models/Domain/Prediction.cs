﻿using ScorePrediction.Web.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace ScorePrediction.Web.Models.Domain
{
    public class Prediction
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }



        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }



        public string MatchId { get; set; }
        public Match Match { get; set; }


        public Guid HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }
        public Guid AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }


        //public ICollection<Match> Match { get; set; }
    }
}
