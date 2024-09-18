namespace KavsarApi.Entites;
public class User
{
    [Key, MaxLength(100),Required]
    public string UserId { get; set; } = null!;
    [MaxLength(100)]
    public string UserName { get; set; } = null!;
    [MaxLength(100)]
    public string HashPassword { get; set; } = null!;
    [MaxLength(50)]
    public string Role { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}