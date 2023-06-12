namespace ExcalibCQRS.Application.Queries;

public class GetUserByEmailResult
{
    public long Id { get; set; }
    public string Email { get; set; } = null!;
}