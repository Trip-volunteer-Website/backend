using System;
using System.Collections.Generic;

namespace TripVolunteer.API.Data
{
    public partial class Login
    {
        public decimal Loginid { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public decimal Userid { get; set; }
        public decimal Roleid { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual Userr User { get; set; } = null!;
    }
}
