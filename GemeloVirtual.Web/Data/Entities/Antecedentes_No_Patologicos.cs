using System;

namespace GemeloVirtual.Web.Data.Entities
{
    public class Antecedentes_No_Patologicos
    {

        public int Id_Antecedente_No_Patologico { get; set; }

        public string Vivienda { get; set; }

        public string Servicios { get; set; }

        public string Higiene { get; set; }

        public string Alimentacion { get; set; }

        public string Habitos { get; set; }

        public bool Mascotas { get; set; }
    }
}