using MediatR;

namespace ExcalibCQRS.Application.Queries;

public class GetUserByEmailQuery: IRequest<GetUserByEmailResult>
{
    public GetUserByEmailQuery(string email)
    {
        Email = email;
    }
    
    public string Email { get; set; }
}