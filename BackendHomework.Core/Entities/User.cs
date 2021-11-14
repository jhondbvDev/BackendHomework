using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BackendHomework.Core.Entities
{
    public class User : IdentityUser
    {
        public virtual ICollection<Plate> Plates { get; set; }
    }
}
