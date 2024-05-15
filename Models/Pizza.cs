using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace la_mia_pizzeria_static.Models
{
    [Table("pizzas")]
    public class Pizza
    {
        [Key]
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public string FotoPath { get; set; }
        public float Prezzo { get; set; }

        public Pizza() { }

        // COSTRUTTORE
        public Pizza(string nome, string descrizione, string fotopath, float prezzo)
        {
            Nome = nome;
            Descrizione = descrizione;
            FotoPath = fotopath;
            Prezzo = prezzo;
        }
    }


}
