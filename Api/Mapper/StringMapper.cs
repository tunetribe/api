using System.Data;
using tunetribe.Api.Database.Interfaces;

namespace tunetribe.Api.Mapper;

public class StringMapper : IDataMapper<string>
{
    public string Map(IDataRecord data) => data.GetString(0);
}