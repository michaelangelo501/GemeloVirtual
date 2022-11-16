using System;

namespace GemeloVirtual.Web.Data.Entities
{
    public class Antecedentes_Patologicos
    {

        public int Id_Antecedente_Patologico { get; set; }

        public string Alergias { get; set; }

        public string Cirugias_Previas { get; set; }

        public string Accidentes_Previos { get; set; }

        public string Enfermedad_Diagnosticada { get; set; }

        public string Infecciones { get; set; }

        public string Uso_Medicamentos { get; set; }

        public bool Transfucion_Sangre { get; set; }

        public bool Tabaco { get; set; }

        public bool Alcohol { get; set; }

    }
}
