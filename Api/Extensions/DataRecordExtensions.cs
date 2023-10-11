using System.Data;

namespace tunetribe.Api.Extensions;

public static class DataRecordExtensions
{
    public static T Get<T>(this IDataRecord data, string name) => (T)data[name];
}