using Microsoft.EntityFrameworkCore.ChangeTracking;
using UserManegment.Dtos;
using UserManegment.Entities;

namespace UserManegment.Services;

public interface IUserService
{
    UserResponse Create(UserCreateParams user);
}

public class UserService(AppDbContext dbContext) : IUserService
{
   
    public UserResponse Create(UserCreateParams dto)
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
        EntityEntry<UserEntity> entity = dbContext.Users.Add(user);
        dbContext.SaveChanges();

        int? age = null;
        if (entity.Entity.BirthDateTime != null)
        {
            age = DateTime.UtcNow.Year - entity.Entity.BirthDateTime.Value.Year; 
        }

        return new UserResponse
        {
            FullName = entity.Entity.FullName,
            Email = entity.Entity.Email,
            PhoneNumber = entity.Entity.PhoneNumber,
            BirthDateTime = entity.Entity.BirthDateTime,
            IsMarried = entity.Entity.IsMarried,
            Age = age
        };
    }  
}
