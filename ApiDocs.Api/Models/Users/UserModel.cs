using MongoDB.Bson;

namespace ApiDocs.Api.Models.Users
{
    /// <summary>
    /// Represents user model
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Id of the user
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// User's username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// User's firstname
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// User's lastname
        /// </summary>
        public string Lastname { get; set; }
    }
}