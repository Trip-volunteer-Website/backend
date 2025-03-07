using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripVolunteer.Core.Data;

namespace TripVolunteer.Core.Services
{
    public interface IRoleService
    {
        List<Role> GetAllRole();
        Role GetRoleById(int id);
        void CreateRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(int id);
    }
}
