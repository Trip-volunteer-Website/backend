using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Services;

namespace TripVolunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService roleService;

       public RoleController(IRoleService roleService)
       { 
        
        this.roleService = roleService;
        
       }

        [HttpGet]
        public List<Role> GetRoles() 
        {
            return roleService.GetAllRole();
        }

        [HttpGet]
        [Route("getrolebyid/{id}")]
        public Role GetRoleById(int id) 
        { 
            return roleService.GetRoleById(id);
        }

        [HttpPost]
        public void CreateRole(Role role) 
        { 
        roleService.CreateRole(role);
        }

        [HttpPut]
        public void UpdateRole(Role role) 
        {
         roleService.UpdateRole(role);
        }

        [HttpDelete]
        [Route("deleterole/{id}")]
        public void DeleteRole(int id) 
        {
            roleService.DeleteRole(id);
        }

    }
}
