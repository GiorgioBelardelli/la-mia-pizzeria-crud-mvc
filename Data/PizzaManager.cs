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

        public static bool ModificaPizza(long id, string nome, string descrizione, string fotopath, float prezzo) 
        {
            using PizzeriaContext db = new PizzeriaContext();
            var pizza = db.Pizze.FirstOrDefault(p => p.Id == id);

            if (pizza == null) 
            {
                return false;

            }

            pizza.Nome = nome;
            pizza.Descrizione = descrizione;
            pizza.FotoPath = fotopath;
            pizza.Prezzo = prezzo;
            db.SaveChanges();

            return true;
        }

        public static bool EliminaPizza(long id)
        {
            using PizzeriaContext db = new PizzeriaContext();
            var pizzaDaEliminare =  db.Pizze.FirstOrDefault(p => p.Id == id);

            if (pizzaDaEliminare == null)
            {
                return false;
            }
            else 
            {
                db.Pizze.Remove(pizzaDaEliminare);
                db.SaveChanges();
                return true;
            }


        }
    }
}
