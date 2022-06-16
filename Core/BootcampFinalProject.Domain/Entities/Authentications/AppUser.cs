using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Domain.Entities.Authentications
{
    public class AppUser : IdentityUser<int>
    {
        public string NameSurname { get; set; }
        public ICollection<Offer>? Offers { get; set; }
    }
}
