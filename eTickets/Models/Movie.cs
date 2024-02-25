﻿using eTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set;}
        public DateTime EndDate { get; set;}
        public double Price { get; set; }
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