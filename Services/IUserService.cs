using Microsoft.EntityFrameworkCore.ChangeTracking;
using UserManegment.Entities;

namespace UserManegment.Services;

public interface IUserService
{
    UserEntity Create(UserEntity user);
}

public class UserService(AppDbContext dbContext) : IUserService
{
   
    public UserEntity Create(UserEntity user)
    {
        EntityEntry<UserEntity> entity = dbContext.Users.Add(user);
        return entity.Entity;
    }  
}
