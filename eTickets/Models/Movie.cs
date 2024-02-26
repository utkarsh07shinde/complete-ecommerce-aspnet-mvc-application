using eTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Movie Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set;}

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set;}
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Display(Name = "Movie Logo")]
        public string ImageURL { get; set; }
        public MovieCategory MovieCategory { get; set; }

        //Relationships
        public List<Actor_Movie>  Actor_Movies { get; set; }

        //Cinemas
        public int CinemasId { get; set; }
        [ForeignKey("CinemasId")]
        public Cinemas Cinemas { get; set; }

        //Producer
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}
