using System;

namespace GemeloVirtual.Web.Data.Entities
{
    public class Reportes_Medicos
    {

        public int Id_Reporte_Medico { get; set; }

        public int Id_Paciente { get; set; }

        public DateTime Fecha { get; set; }

    }
}

