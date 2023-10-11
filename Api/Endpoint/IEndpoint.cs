namespace tunetribe.Api.Endpoint;

public interface IEndpoint<TArguments, TResult>
{
    public TResult Get(TArguments arguments);
}