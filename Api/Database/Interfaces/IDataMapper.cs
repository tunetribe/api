using System.Data;

namespace tunetribe.Api.Database.Interfaces;

public interface IDataMapper<T>
{
    public T Map(IDataRecord data);
}