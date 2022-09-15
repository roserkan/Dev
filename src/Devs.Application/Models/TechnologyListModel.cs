using Core.Persistence.Paging;
using Devs.Application.Dtos.Technologies;

namespace Devs.Application.Models;

public class TechnologyListModel : BasePageableModel
{
    public IList<TechnologyDto> Items { get; set; }
}
