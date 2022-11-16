using System;

namespace GemeloVirtual.Web.Data.Entities
{
    public class Admision_Hospital
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public int Id_Hospital { get; set; }

        public int Id_Paciente { get; set; }
    }
}
