using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ApiDocs.Api.Models.Users;
using MongoDB.Bson;

namespace ApiDocs.Api.Controllers
{
    public class UserController : ApiController
    {
        /// <summary>
        /// Some dummy users list
        /// </summary>
        public static readonly List<UserModel> DummyUsers;

        /// <summary>
        /// STATIC CTOR
        /// </summary>
        static UserController()
        {
            DummyUsers = new List<UserModel>
                {
                    new UserModel
                        {
                            Id = ObjectId.GenerateNewId(),
                            Firstname = @"User_A_Firstname",
                            Lastname = @"User_A_Lastname",
                            Username = @"usera"
                        },
                    new UserModel
                        {
                            Id = ObjectId.GenerateNewId(),
                            Firstname = @"User_B_Firstname",
                            Lastname = @"User_B_Lastname",
                            Username = @"userb"
                        }
                };
        }

        /// <summary>
        /// Return all available users
        /// </summary>
        /// <returns></returns>
        public List<UserModel> Get()
        {
            return DummyUsers;
        }

        /// <summary>
        /// return user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserModel Get(ObjectId id)
        {
            return DummyUsers.FirstOrDefault();
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="userModel"></param>
        public void New(UserModel userModel)
        {

        }

        /// <summary>
        /// Remove existing user
        /// </summary>
        /// <param name="id"></param>
        public void Delete(ObjectId id)
        {
        }
    }
}