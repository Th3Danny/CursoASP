using System.Collections.Generic;
using CursoASPAjax.Repositories;

namespace CursoASPAjax.IServices.Services
{
    using CursoASPAjax;

    public class PersonasService : IPersonasService
    {
        private readonly PersonasRepository _repo = new PersonasRepository();

        public List<PersonasPorPaisVM> ListarPersonasPorPais(int idPais)
        {
            return _repo.GetPersonasByPais(idPais);
        }

        public List<Personas> ListarTodas()
        {
            return _repo.GetAllPersonas();
        }

        public Personas ObtenerPorId(int id)
        {
            return _repo.GetById(id);
        }

        public void Insertar(Personas persona)
        {
            _repo.Insert(persona);
        }

        public void Actualizar(Personas persona)
        {
            _repo.Update(persona);
        }

        public void Eliminar(int id)
        {
            _repo.Delete(id);
        }

        public List<Paises> ListarPaises()
        {
            return _repo.GetPaises();
        }
    }
}
