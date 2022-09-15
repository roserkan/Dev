using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public class OtpAuthenticator : Entity
{
    public int UserId { get; set; }
    public byte[] SecretKey { get; set; }
    public bool IsVerified { get; set; }

    public virtual User User { get; set; }
}