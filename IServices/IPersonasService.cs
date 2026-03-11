using System.Collections.Generic;

namespace CursoASPAjax.IServices
{

    using CursoASPAjax;

    public interface IPersonasService
    {
        List<PersonasPorPaisVM> ListarPersonasPorPais(int idPais);
        List<Personas> ListarTodas();
        Personas ObtenerPorId(int id);
        void Insertar(Personas persona);
        void Actualizar(Personas persona);
        void Eliminar(int id);
        List<Paises> ListarPaises();
    }
}
