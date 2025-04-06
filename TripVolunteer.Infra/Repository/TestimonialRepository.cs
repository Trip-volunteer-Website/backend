using Dapper;
using System.Data;
using TripVolunteer.Core.Common;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Repository;

namespace TripVolunteer.Infra.Repository
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly IDbContext _dbContext;

        public TestimonialRepository(IDbContext dbContext)
        {

            _dbContext = dbContext;

        }

        public void DeleteTestimonial(int id)
        {
            var p = new DynamicParameters();
            p.Add("testimonial_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Testimonial_package.deleteTestimonial", p, commandType: CommandType.StoredProcedure);
        }

        public List<Testimonial> GetAllTestimonials()
        {
            // استرجاع بيانات Testimonial فقط من قاعدة البيانات
            var testimonials = _dbContext.Connection.Query<Testimonial>(
                "Testimonial_package.GetAllTestimonial",
                commandType: CommandType.StoredProcedure
            ).ToList();

            // الآن، يمكنك تحديث كل Testimonial بحيث تتضمن User المرتبط به
            foreach (var testimonial in testimonials)
            {
                // استرجاع بيانات المستخدم باستخدام UserId
                var user = _dbContext.Connection.QuerySingleOrDefault<Userr>(
                    "SELECT * FROM Userr WHERE Userid = :UserId",
                    new { UserId = testimonial.Userid }
                );

                // تعيين الـ User للمراجعة
                testimonial.User = user;
            }

            return testimonials;
        }

       public List<Testimonial> GetAllActiveTestimonials()
        {
            // استرجاع بيانات Testimonial فقط من قاعدة البيانات
            var testimonials = _dbContext.Connection.Query<Testimonial>(
                "Testimonial_package.GetAllActiveTestimonial",
                commandType: CommandType.StoredProcedure
            ).ToList();

            // الآن، يمكنك تحديث كل Testimonial بحيث تتضمن User المرتبط به
            foreach (var testimonial in testimonials)
            {
                // استرجاع بيانات المستخدم باستخدام UserId
                var user = _dbContext.Connection.QuerySingleOrDefault<Userr>(
                    "SELECT * FROM Userr WHERE Userid = :UserId",
                    new { UserId = testimonial.Userid }
                );

                // تعيين الـ User للمراجعة
                testimonial.User = user;
            }

            return testimonials;
        }
        public Testimonial GetTestimonialById(int id)
        {

            var p = new DynamicParameters();
            p.Add("testimonial_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Testimonial> result = _dbContext.Connection.Query<Testimonial>
                ("Testimonial_package.getTestimonialbyid", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public void makeTestimonial(Testimonial testimonial)
        {
            var p = new DynamicParameters();
            p.Add("user_id", testimonial.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("user_content", testimonial.Content, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("user_status", "pending", dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Testimonial_package.makeTestimonial", p, commandType: CommandType.StoredProcedure);

        }

        public void UpdateTestimonial(Testimonial testimonial)
        {
            var p = new DynamicParameters();
            p.Add("testimonial_id", testimonial.Testimonialid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("user_id", testimonial.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("user_content", testimonial.Content, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("user_status", testimonial.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Testimonial_package.updateTestimonial", p, commandType: CommandType.StoredProcedure);

        }
        public void ApprovOrRejectTestimonial(int testimonialId, string newStatus)
        {
            var p = new DynamicParameters();
            p.Add("testimonial_id", testimonialId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("new_status", newStatus, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Testimonial_package.ApprovOrRejectTestimonial", p, commandType: CommandType.StoredProcedure);
        }

        public List<Testimonial> GetTestimonialCountByStatus()
        {
            var p = new DynamicParameters();
            var result = _dbContext.Connection.Query<Testimonial>(
                "Testimonial_package.GetTestimonialCountByStatus",
                p,
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }

    }
}
