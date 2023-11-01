using System.Data;
using tunetribe.Api.Database.Interfaces;
using tunetribe.Core.Model;

namespace tunetribe.Api.Mapper;

public class UserMapper : IDataMapper<User>
{
    public User Map(IDataRecord data) => new User(
        Identifier: data.GetInt32(0),
        Username: data.GetString(1), 
        PasswordHash: data.GetString(2)
    );
}