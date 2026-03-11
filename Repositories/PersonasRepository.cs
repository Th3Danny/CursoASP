using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.SqlClient;
using CursoASPAjax;

namespace CursoASPAjax.Repositories
{

    public class PersonasRepository
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // 1. Consulta avanzada con SP y ViewModel (Mejor práctica para Joins)
        public List<PersonasPorPaisVM> GetPersonasByPais(int idPais)
        {
            var param = new SqlParameter("@IdPais", idPais);
            
            // Mapeamos el resultado directamente al ViewModel específico
            return _db.Database.SqlQuery<PersonasPorPaisVM>(
                "exec sp_BuscarPersonaPorPais @IdPais", 
                param
            ).ToList();
        }

        public List<Personas> GetAllPersonas()
        {
            return _db.Personas.Include(p => p.Paises).ToList();
        }

        public Personas GetById(int id)
        {
            return _db.Personas.Include(p => p.Paises).FirstOrDefault(p => p.Id == id);
        }

        public void Insert(Personas persona)
        {
            _db.Personas.Add(persona);
            _db.SaveChanges();
        }

        public void Update(Personas persona)
        {
            _db.Entry(persona).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var persona = _db.Personas.Find(id);
            if (persona != null)
            {
                _db.Personas.Remove(persona);
                _db.SaveChanges();
            }
        }

        public List<Paises> GetPaises()
        {
            return _db.Paises.ToList();
        }
    }
}