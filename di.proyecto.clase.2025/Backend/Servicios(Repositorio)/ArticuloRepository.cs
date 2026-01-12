using Castle.Core.Logging;
using di.proyecto.clase._2025.Backend.Modelos;
using di.proyecto.clase._2025.Backend.Servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace di.proyecto.clase._2025.Backend.Servicios_Repositorio_
{
    public class ArticuloRepository: GenericRepository<Articulo>, IArticuloRepository
    {
        public ArticuloRepository(DiinventarioexamenContext context,ILogger<GenericRepository<Articulo>> logger)
        :base(context,logger)
        { }

        public async Task<int?> GetUltimoIdAsync()
        {
            return await _dbSet.MaxAsync(a => (int?)a.Idarticulo);
        }

    }
}
