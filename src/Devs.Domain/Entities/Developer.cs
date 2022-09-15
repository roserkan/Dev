using Core.Security.Entities;

namespace Devs.Domain.Entities;

public class Developer : User
{
    public virtual SocialProfile SocialProfile { get; set; }
}
