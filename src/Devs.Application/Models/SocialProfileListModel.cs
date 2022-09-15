using Core.Persistence.Paging;
using Devs.Application.Dtos.SocialProfiles;

namespace Devs.Application.Models;

public class SocialProfileListModel : BasePageableModel
{
    public IList<SocialProfileDto> Items { get; set; }
}