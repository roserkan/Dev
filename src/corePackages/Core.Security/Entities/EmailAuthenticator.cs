using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public class EmailAuthenticator : Entity
{
    public int UserId { get; set; }
    public string? ActivationKey { get; set; }
    public bool IsVerified { get; set; }

    public virtual User User { get; set; }
}