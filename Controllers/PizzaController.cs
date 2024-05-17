using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
                //List<Pizza> pizze = AggiungiPizze();

                //foreach (var pizza in pizze)
                //{
                //db.Pizze.Add(pizza);
                //}

                //db.SaveChanges();

                List<Pizza> pizze = PizzaManager.GetAllPizzas();
                return View("Index", pizze);
        }

        public IActionResult Show(int id)
        {

            var pizza = PizzaManager.GetPizza(id); 
            return View(pizza);

        }

        public IActionResult Create()
        {
            return View("Create");        
        }

        //Action che fornisce la view con la form per creare una pizza
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza pizza)
        {
            if (!ModelState.IsValid) 
            {
                return View("Create", pizza);
            }
            PizzaManager.AggiungiPizza(pizza);
            return RedirectToAction("Index");

        }

        //Action che fornisce la view con la form per modificare una pizza
        [HttpGet]
        public IActionResult Update(int id)
        {
            var pizzaDaModificare = PizzaManager.GetPizza(id);
            if (pizzaDaModificare == null)
            {
                return NotFound();
            }
            else 
            {
                return View(pizzaDaModificare);
            
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", pizza);
            }


            if(PizzaManager.ModificaPizza(id, pizza.Nome, pizza.Descrizione, pizza.FotoPath, pizza.Prezzo))
            {
                return RedirectToAction("Index");
            }
            else 
            {
                return NotFound();
            }

        }

        //Action per eliminare una pizza
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (PizzaManager.EliminaPizza(id))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
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
