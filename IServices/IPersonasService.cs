using System.Collections.Generic;

namespace CursoASPAjax.IServices
{

    using CursoASPAjax;

    public interface IPersonasService
    {
        List<PersonasPorPaisVM> ListarPersonasPorPais(int idPais);

        List<string> BuscarPersonas(string term);
        List<Personas> FiltrarPersonas(string term);
        List<Personas> FiltrarPorEdad(int min, int max);

        List<Personas> ListarTodas();
        Personas ObtenerPorId(int id);
        void Insertar(Personas persona);
        void Actualizar(Personas persona);
        void Eliminar(int id);
        List<Paises> ListarPaises();
    }
}
