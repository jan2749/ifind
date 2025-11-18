#nullable disable
using System;
using System.ComponentModel.DataAnnotations;
namespace web.Models
{
    public class Lokacija
    {
        public int Id { get; set; }

        [Required] public double Latitude { get; set; }
        [Required] public double Longitude { get; set; }

        public string Naslov { get; set; }  //opcijsko za lepši izpis

        // Vsaka enemu dogodku (1:1)
        public int DogodekId { get; set; }
        public virtual Dogodek Dogodek { get; set; }
    }
}