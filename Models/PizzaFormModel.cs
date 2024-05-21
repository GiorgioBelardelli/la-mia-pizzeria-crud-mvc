using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_static.Models
{
    public class PizzaFormModel
    {
        public Pizza Pizza { get; set; }
        public List<Categoria>? Categorie { get; set; }
        public PizzaFormModel() { }

        public PizzaFormModel(Pizza pizza, List<Categoria> categorie)
        {
            this.Pizza = pizza;
            this.Categorie = categorie;
        }
    }
}
