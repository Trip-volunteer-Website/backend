using System;
using System.Collections.Generic;

namespace TripVolunteer.API.Data
{
    public partial class Role
    {
        public Role()
        {
            Logins = new HashSet<Login>();
            Userrs = new HashSet<Userr>();
        }

        public decimal Roleid { get; set; }
        public string Rolename { get; set; } = null!;

        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Userr> Userrs { get; set; }
    }
}
