using Core.Persistence.Paging;
using Devs.Application.Dtos.ProgrammingLanguages;

namespace Devs.Application.Models;

public class ProgrammingLanguageListModel : BasePageableModel
{
    public IList<ProgrammingLanguageDto> Items { get; set; }
}