using System;

namespace GemeloVirtual.Web.Data.Entities
{
    public class Patient
    {
        public int Id { get; set; }

        public User User { get; set; }

        public DateTime Birthday { get; set; }
    }
}
