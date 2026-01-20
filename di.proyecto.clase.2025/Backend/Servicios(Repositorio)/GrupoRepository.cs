using Castle.Core.Logging;
using di.proyecto.clase._2025.Backend.Modelos;
using di.proyecto.clase._2025.Backend.Servicios;
using Microsoft.Extensions.Logging;

namespace di.proyecto.clase._2025.Backend.Servicios_Repositorio_
{
    public class GrupoRepository : GenericRepository<Grupo>, IGrupoRepository
    {
        public GrupoRepository(DiinventarioexamenContext context, ILogger<GenericRepository<Grupo>> logger)
            : base(context, logger)
        {

        }
    }
}
