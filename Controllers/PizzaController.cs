using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                //List<Pizza> pizze = AggiungiPizze();

                //foreach (var pizza in pizze)
                //{
                //db.Pizze.Add(pizza);
                //}

                //db.SaveChanges();

                List<Pizza> pizze = GetPizzasFromDatabase();
                return View("Index", pizze);
            }
        }

        public IActionResult Show(int id)
        {

            using (PizzeriaContext db = new PizzeriaContext())
            {
                var pizza = db.Pizze.Find(id);

                if (pizza == null)
                {
                    return View("Error");
                }
                return View(pizza);
            }

        }

        private List<Pizza> GetPizzasFromDatabase()
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                return db.Pizze.ToList();
            }
        }

        //private List<Pizza> AggiungiPizze()
        //{
            //List<Pizza> listaPizze = new List<Pizza>
            //{
                //new Pizza { Nome = "Margherita", Descrizione = "Pomodoro, Mozzarella, Basilico", FotoPath = "https://images.prismic.io/eataly-us/ed3fcec7-7994-426d-a5e4-a24be5a95afd_pizza-recipe-main.jpg?auto=compress,format", Prezzo = 5.99f },
                //new Pizza { Nome = "Boscaiola", Descrizione = "Mozzarella, Salsiccia, Funghi", FotoPath = "https://www.alfaforni.com/wp-content/uploads/2018/08/pizza-boscaiola-wild-traditional-mushroom-pizza.jpg", Prezzo = 8.99f },
                //new Pizza { Nome = "Parmigiana", Descrizione = "Pomodoro, Mozzarella, Melanzane, Parmigiano, Basilico", FotoPath = "https://wips.plug.it/cips/buonissimo.org/cms/2023/01/pizza-con-parmigiana-di-melanzane.jpg", Prezzo = 7.99f },
                //new Pizza { Nome = "Capricciosa", Descrizione = "Pomodoro, Mozzarella, Funghi, Prosciutto Crudo, Uovo, Olive", FotoPath = "https://www.italianmenumaster.com/images/67.jpg", Prezzo = 8.99f },

            //};

            //return listaPizze;
        //}
    }
}
