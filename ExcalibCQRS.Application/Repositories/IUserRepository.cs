using ExcalibCQRS.Domain.Models;

namespace ExcalibCQRS.Application.Repositories;

public interface IUserRepository
{
    Task<User> GetById(long id);
    Task<User> GetByEmail(string email);
    Task<long> Create(User user);
}