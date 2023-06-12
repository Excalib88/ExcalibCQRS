using ExcalibCQRS.Application.Queries;
using ExcalibCQRS.Application.Repositories;
using MediatR;

namespace ExcalibCQRS.Infrastructure.Queries;

public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, GetUserByEmailResult>
{
    private readonly IUserRepository _userRepository;

    public GetUserByEmailHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUserByEmailResult> Handle(GetUserByEmailQuery query, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmail(query.Email);

        return new GetUserByEmailResult
        {
            Email = user.Email,
            Id = user.Id
        };
    }
}