using ExcalibCQRS.Application.Commands;
using ExcalibCQRS.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExcalibCQRS.Web.Controllers;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetUserByEmail([FromQuery] string email)
    {
        var user = await _mediator.Send(new GetUserByEmailQuery(email));

        return Ok(new {user});
    }

    [HttpPost]
    public async Task<IActionResult> Create(AddUserCommand command)
    {
        var id = await _mediator.Send(command);
        
        return Ok(new {id});
    }
}