#nullable disable
using System;
using System.ComponentModel.DataAnnotations;
namespace web.Models
{
    public class Kategorija
    {
        public int Id { get; set; }

        [Required] 
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public virtual ICollection<Dogodek> Dogodki { get; set; }
    }    
}
