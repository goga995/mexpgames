namespace Domain.Shared;

public sealed record Error(string Code, string Description)
{
    public static readonly Error None = new(string.Empty, string.Empty);
    public static readonly Error NullValue = new("Error.NullValue", "NullValue was provided");

    public static implicit operator string(Error error) => error?.Code ?? string.Empty;

    public Result ToResult() => Result.Failure(this);
}