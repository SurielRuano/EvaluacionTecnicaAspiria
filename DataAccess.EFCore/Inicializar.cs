using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.EFCore
{
   public class Inicializar
    {
        public static void Initialize(ApplicationContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Productos.Any())
            {
                return;   // DB has been seeded
            }

            var productos = new Producto[]
            {
            new Producto{Compania = "Fisher Price", Descripcion = "Juguete para bebes", Nombre ="Leon de colores", RestriccionEdad= 3, Precio = 120 },
            new Producto{Compania = "Lego", Descripcion = "Juguete didáctico", Nombre = "Batman Lego", RestriccionEdad = 8, Precio = 240 },
            new Producto{Compania = "Chicco", Descripcion = "Guantes ", Nombre ="Guantes cuentacuentos", RestriccionEdad= 3, Precio = 320 },
            new Producto{Compania = "Mattel Games", Descripcion = "Juego de mesa", Nombre ="Uno", RestriccionEdad= 3, Precio = 145 },
            new Producto{Compania = "Mattel Games", Descripcion = "Torre hot wheels", Nombre ="Hot wheels City Ultimate", RestriccionEdad= 9, Precio = 850 },
            };
            foreach (var producto in productos)
            {
                context.Productos.Add(producto);
            }
            context.SaveChanges();
        
        }
    }
}
