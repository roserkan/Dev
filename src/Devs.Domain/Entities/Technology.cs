using Core.Persistence.Repositories;

namespace Devs.Domain.Entities;

public class Technology: Entity
{
    public int ProgrammingLanguageId { get; set; }
    public string Name { get; set; }
    public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }
}

