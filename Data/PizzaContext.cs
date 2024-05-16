using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using la_mia_pizzeria_static.Models;

namespace la_mia_pizzeria_static.Data
{
    public class PizzeriaContext : DbContext
    {
        public DbSet<Pizza> Pizze { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db-pizze;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
