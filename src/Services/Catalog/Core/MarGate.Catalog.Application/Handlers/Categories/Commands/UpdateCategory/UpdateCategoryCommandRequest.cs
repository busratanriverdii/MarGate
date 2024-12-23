using MarGate.Core.CQRS.Command;

namespace MarGate.Catalog.Application.Handlers.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandRequest : Command<UpdateCategoryCommandResponse>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
