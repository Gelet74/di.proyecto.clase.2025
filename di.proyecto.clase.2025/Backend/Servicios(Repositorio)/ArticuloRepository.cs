using di.proyecto.clase._2025.Backend.Modelos;
using di.proyecto.clase._2025.Backend.Servicios;
using Microsoft.Extensions.Logging;

namespace di.proyecto.clase._2025.Backend.Servicios_Repositorio_
{
    public class ArticuloRepository: GenericRepository<Articulo>, IArticuloRepository
    {
        public ArticuloRepository(DiinventarioexamenContext context,ILogger<GenericRepository<Articulo>> logger)
        :base(context,logger)
        { 
        
        }

        public async Task<int> GetLastCodigoEmpleadoAsync()
        {
            try
            {
                int codigo;
                var list = await QueryAsync(q => q.OrderByDescending(e => e.Idarticulo).Take(1)).ConfigureAwait(false);
                var first = list.FirstOrDefault();
                if (first == null)
                {
                    codigo = 0;
                    //Logger.Info("GetLastCodigoEmpleadoAsync: no hay empleados, se asigna CodigoEmpleado={0}", codigo);
                }
                else { codigo = first.Idarticulo; }
                return codigo;
            }
            catch (Exception ex)
            {
                //Logger.Error(ex, "GetLastCodigoEmpleadoAsync fallo.");
                throw;
            }
        }
    }
}
