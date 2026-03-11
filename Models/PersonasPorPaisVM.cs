using System;

namespace CursoASPAjax
{
    // Este ViewModel es específico para recibir los datos del SP sp_BuscarPersonaPorPais
    // Evita modificar el modelo de base de datos original
    public class PersonasPorPaisVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
    }
}
