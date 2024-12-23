using MarGate.Core.CQRS.Command;

namespace MarGate.Catalog.Application.Handlers.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandRequest : Command<DeleteCategoryCommandResponse>
{
    public long Id { get; set; }
}
