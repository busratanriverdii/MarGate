using MarGate.Core.CQRS.Command;

namespace MarGate.Catalog.Application.Handlers.Categories.Commands.CreateCategory;

public class CreateCategoryCommandRequest : Command<CreateCategoryCommandResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
