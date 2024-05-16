﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace la_mia_pizzeria_static.Models
{
    [Table("pizzas")]
    public class Pizza
    {
        [Key]
        public long Id { get; set; }
        
        [Required(ErrorMessage = "Campo obbligatorio")]
        [StringLength(30, ErrorMessage = "Massimo 30 caratteri")]
        [MinLength(3)]

        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [StringLength(100, ErrorMessage = "Massimo 100 caratteri")]
        [MinLength(5)]
        public string Descrizione { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string FotoPath { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Range(0.01, 999.99, ErrorMessage = "Il prezzo deve essere compreso tra 0,01 e 999,99.")]
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
