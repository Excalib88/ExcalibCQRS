using ExcalibCQRS.Application.Commands;
using ExcalibCQRS.Application.Repositories;
using ExcalibCQRS.Domain.Models;
using MediatR;

namespace ExcalibCQRS.Infrastructure.Commands;

public class AddUserHandler : IRequestHandler<AddUserCommand, long>
{
    private readonly IUserRepository _userRepository;

    public AddUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<long> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        return await _userRepository.Create(new User
        {
            Email = request.Email
        });
    }
}