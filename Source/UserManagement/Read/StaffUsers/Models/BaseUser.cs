using System;
using Dolittle.ReadModels;
using Infrastructure.Read;
using MongoDB.Bson.Serialization;

namespace Read.StaffUsers.Models
{
    public abstract class BaseUser : IReadModel
    {
        public Guid StaffUserId { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }

        protected BaseUser(Guid staffUserId, string fullName, string displayName, string email, DateTimeOffset registrationDate)
        {
            StaffUserId = staffUserId;
            FullName = fullName;
            DisplayName = displayName;
            Email = email;
            RegistrationDate = registrationDate;
        }
    }

    public class BaseUserClassMap : MongoDbClassMap<BaseUser>
    {
        public override void Map(BsonClassMap<BaseUser> cm)
        {
            cm.AutoMap();
            cm.MapIdMember(g => g.StaffUserId);
        }

        public override void Register()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(BaseUser)))
                BsonClassMap.RegisterClassMap<BaseUser>(Map);
        }
    }
}