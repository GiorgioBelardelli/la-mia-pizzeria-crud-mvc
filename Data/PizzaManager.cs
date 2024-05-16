using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;


namespace la_mia_pizzeria_static.Data

{
    public class PizzaManager
    {

        //Metodo nel manager per restituirmi una lista di pizze
        public static List<Pizza> GetAllPizzas()
        {
            using PizzeriaContext db = new PizzeriaContext();
            return db.Pizze.ToList();
        }

        //Metodo nel manager per restituirmi una pizza sola
        public static Pizza GetPizza(long id)
        {
            using PizzeriaContext db = new PizzeriaContext();
            return db.Pizze.FirstOrDefault(p => p.Id == id);
        }

        //Metodo per aggiungere le pizze al database Pizze
        public static void AggiungiPizza(Pizza pizza)
        {
            using PizzeriaContext db = new PizzeriaContext();
            db.Pizze.Add(pizza);
            db.SaveChanges();
        }
    }
}
