#nullable disable
namespace web.Models
{
    public class Udelezba
    {
        public int UporabnikId { get; set; }
        public virtual Uporabnik Uporabnik { get; set; }

        public int DogodekId { get; set; }
        public virtual Dogodek Dogodek { get; set; }

        public DateTime DatumPrijave { get; set; } = DateTime.UtcNow;

        // PK-uporabnikid+dogodekid (OnModelCreating!)
    }
}