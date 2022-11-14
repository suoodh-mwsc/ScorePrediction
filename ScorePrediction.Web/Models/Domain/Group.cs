using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScorePrediction.Web.Models.Domain
{
    public class Group
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }



        [Required, DisplayName("Name")]
        public string Name { get; set; }


        //Guid TeamId { get; set; }
        //public Team Team { get; set; }


        [ForeignKey("Tournament")]
        Guid TournamentId { get; set; }
        public Tournament Tournament { get; set; }
    }
}
