using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Repository;
using TripVolunteer.Core.Services;

namespace TripVolunteer.Infra.Services
{
    public class RoleService : IRoleService
    {
        //inject role repo using interface 
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public void CreateRole(Role role)
        {
            _roleRepository.CreateRole(role);   
        }

        public void DeleteRole(int id)
        {
            _roleRepository.DeleteRole(id);
        }

        public List<Role> GetAllRole()
        {
            return _roleRepository.GetAllRole();
        }

        public Role GetRoleById(int id)
        {
           return _roleRepository.GetRoleById(id);
        }

        public void UpdateRole(Role role)
        {
           _roleRepository.UpdateRole(role);
        }
    }
}
