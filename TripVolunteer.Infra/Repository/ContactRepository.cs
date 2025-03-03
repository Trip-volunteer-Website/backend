using Dapper;
using System.Data;
using TripVolunteer.Core.Common;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Repository;

namespace TripVolunteer.Infra.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDbContext _dbContext;

        public ContactRepository(IDbContext dbContext)
        {

            _dbContext = dbContext;

        }

        public void deletecontact(int id)
        {
            var p = new DynamicParameters();
            p.Add("image_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("contact_package.deletecontact", p, commandType: CommandType.StoredProcedure);

        }

        public List<Contact> GetAllcontact()
        {
            IEnumerable<Contact> result = _dbContext.Connection.Query<Contact>
            ("contact_package.GetAllcontact", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Contact getcontactbyid(int id)
        {
            var p = new DynamicParameters();
            p.Add("contact_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Contact> result = _dbContext.Connection.Query<Contact>
                ("contact_package.getcontactbyid", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public void makecontact(Contact contact)
        {
            var p = new DynamicParameters();
            p.Add("contact_name", contact.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("contact_email", contact.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("phone_number", contact.Phonenumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("c_content", contact.Content, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("contact_package.makecontact", p, commandType: CommandType.StoredProcedure);

        }

        public void updatecontact(Contact contact)
        {
            var p = new DynamicParameters();
            p.Add("contact_id", contact.Contactid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("contact_name", contact.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("contact_email", contact.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("phone_number", contact.Phonenumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("c_content", contact.Content, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("contact_package.makecontact", p, commandType: CommandType.StoredProcedure);

        }
    }
}
