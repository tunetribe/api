using System.Data;
using tunetribe.Api.Database.Interfaces;
using tunetribe.Api.Extensions;

namespace tunetribe.Api.Mapper;

public class BooleanMapper : IDataMapper<bool>
{
    public bool Map(IDataRecord data) => data.Get<bool>("result");
}