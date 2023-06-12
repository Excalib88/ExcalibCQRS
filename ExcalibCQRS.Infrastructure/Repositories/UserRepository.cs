using ExcalibCQRS.Application.Repositories;
using ExcalibCQRS.Domain.Exceptions;
using ExcalibCQRS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcalibCQRS.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetById(long id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

        if (user == null)
        {
            throw new EntityNotFoundException();
        }
        
        return user;
    }

    public async Task<User> GetByEmail(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        
        if (user == null)
        {
            throw new EntityNotFoundException();
        }
        
        return user;
    }

    public async Task<long> Create(User user)
    {
        var result = await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return result.Entity.Id;
    }
}