using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.Dependencies;
using UsersAndAwards.DAL.SQLiteDAO;
using UsersAndAwards.Entities;

namespace UsersAndAwards.PL.ConsolePL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var GuidUserA= Guid.NewGuid();
            var GuidUserB = Guid.NewGuid();

            var GuidAwardA = Guid.NewGuid();
            var GuidAwardB = Guid.NewGuid();

            var db = new SqliteDAO();

            //db.CreateUserCommand(
            //    new UserEntity
            //    {
            //        Id = GuidUserA,
            //        Name = "A",
            //        DateOfBirth = DateTime.Now,
            //        Awards = new List<AwardEntity>()
            //    });

            //db.CreateAwardCommand(
            //    new AwardEntity
            //    {
            //        Id =
            //    });


        }
    }
}