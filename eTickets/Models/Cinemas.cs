using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinemas : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Cinema Logo")]
        public string Logo { get; set; }

        [Display(Name ="Cinema Name")]
        public string Name { get; set; }
        [Display(Name ="Description")]
        public string Description { get; set; }

        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
