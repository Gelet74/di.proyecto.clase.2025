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

        public override async Task<List<Articulo>> GetAllAsync()
        {
            return await _dbSet
                .Include(a => a.EspacioNavigation)
                .Include(a => a.UsuarioaltaNavigation)
                .Include(a => a.DepartamentoNavigation)
                .Include(a => a.ModeloNavigation)

                .ToListAsync();
        }


    }
}
