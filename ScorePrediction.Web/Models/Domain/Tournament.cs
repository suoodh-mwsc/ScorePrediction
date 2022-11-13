﻿using FenClub.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorePrediction.Domain
{
    public class Tournament
    {
        [Key]
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }

        [Required, DisplayName("Name"), MaxLength(50)]
        public string Name { get; set; }


        [Required, DisplayName("Start On")]
        public DateTime StartOn { get; set; }


        [Required, DisplayName("End On")]
        public DateTime EndOn { get; set; }


        [Required, DisplayName("Score Prediction")]
        public Boolean ScorePrediction { get; set; }


        [DisplayName("Published On")]
        public DateTime? PublishedOn { get; set; }


        public IEnumerable<Match> TournamentMatches { get; set; }
    }
}
