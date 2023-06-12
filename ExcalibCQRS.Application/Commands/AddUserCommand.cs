using MediatR;

namespace ExcalibCQRS.Application.Commands;

public class AddUserCommand : IRequest<long>
{
    public string Email { get; set; } = null!;
}