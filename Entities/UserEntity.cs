using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManegment.Entities;

[Table("Users")]
public class UserEntity
{
    [Key]
    public Guid Id { get; set; }

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