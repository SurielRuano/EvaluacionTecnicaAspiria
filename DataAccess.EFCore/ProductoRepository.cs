using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EFCore
{
    public class ProductoRepository: Repository<Producto>, IProductoRepository
    {
        protected readonly ApplicationContext _context;
        public ProductoRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public void Insertar(IEnumerable<Producto> entities)
        {
            _context.Set<Producto>().AddRange(entities);
        }
    }
}
