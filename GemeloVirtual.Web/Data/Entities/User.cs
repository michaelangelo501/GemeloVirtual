using Microsoft.AspNetCore.Identity;

namespace GemeloVirtual.Web.Data.Entities
{
    public class User :IdentityUser
    {
        //Esperemos que jale
        //Espero que si
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
