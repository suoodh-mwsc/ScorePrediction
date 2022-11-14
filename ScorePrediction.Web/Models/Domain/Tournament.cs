using ScorePrediction.Web.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorePrediction.Web.Models.Domain
{
    public class Tournament
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
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

        [DisplayName("Image")]
        public string Image { get; set; }



        public IList<Match> TournamentMatches { get; set; }

        public IList<Group> TournamentGroups { get; set; }
    }
}
