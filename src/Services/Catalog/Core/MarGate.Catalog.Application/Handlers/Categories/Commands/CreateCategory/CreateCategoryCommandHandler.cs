﻿using MarGate.Catalog.Domain.Entities;
using MarGate.Core.CQRS.Command;
using MarGate.Core.Persistence.Repository;
using MarGate.Core.Persistence.UnitOfWork;

namespace MarGate.Catalog.Application.Handlers.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler(IUnitOfWork unitOfWork) : CommandHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
{
    private readonly IWriteRepository<Category> _categoryWriteRepository = unitOfWork.GetWriteRepository<Category>();

    public async override Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request,
        CancellationToken cancellationToken)
    {
        var category = new Category(request.Name, request.Description);

        var id = _categoryWriteRepository.Create(category);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateCategoryCommandResponse()
        {
            IsSuccess = true,
            Id = id
        };
    }
}
