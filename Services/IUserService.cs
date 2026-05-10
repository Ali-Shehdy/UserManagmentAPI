using Microsoft.EntityFrameworkCore.ChangeTracking;
using UserManegment.Dtos;
using UserManegment.Entities;

namespace UserManegment.Services;

public interface IUserService
{
    Task<UserResponse> Create(UserCreateParams user);
}

public class UserService(AppDbContext dbContext) : IUserService
{
   
    public async Task<UserResponse> Create(UserCreateParams dto)
    {
        UserEntity user = new()
        {
            Id = Guid.CreateVersion7(),
            FullName = dto.FullName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            BirthDateTime = dto.BirthDateTime,
            IsMarried = dto.IsMarried,
        };
        UserEntity entity = dbContext.Users.Add(user).Entity;
        await dbContext.SaveChangesAsync();

        int? age = null;
        if (entity.BirthDateTime != null)
        {
            age = DateTime.UtcNow.Year - entity.BirthDateTime.Value.Year; 
        }

        return new UserResponse
        {
            FullName = entity.FullName,
            Email = entity.Email,
            PhoneNumber = entity.PhoneNumber,
            BirthDateTime = entity.BirthDateTime,
            IsMarried = entity.IsMarried,
            Age = age
        };
    }  
}
