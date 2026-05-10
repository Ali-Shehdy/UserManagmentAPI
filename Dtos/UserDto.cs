using System.ComponentModel.DataAnnotations;

namespace UserManegment.Dtos;

public class UserCreateParams
{
    

    [Required]
    [MinLength(2)]
    [MaxLength(50)]
    public required string FullName { get; set; }
    
    [EmailAddress] 
    [MinLength(2)]
    [MaxLength(50)]
    public  required string Email { get; set; }
    
    [Required]
    [MaxLength(12)]
    [MinLength(10)]
    public required string PhoneNumber { get; set; }

    public DateTime? BirthDateTime { get; set; }

    public Boolean IsMarried { get; set; } =  false;

}

public class UserResponse{
    
    public required string FullName { get; set; }
    public  required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public DateTime? BirthDateTime { get; set; }
    public Boolean IsMarried { get; set; } =  false;
    public int? Age { get; set; }
}