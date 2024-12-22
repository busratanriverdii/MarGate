using MarGate.Core.CQRS.Command;
using MarGate.Core.Persistence.Repository;
using MarGate.Core.Persistence.UnitOfWork;
using MarGate.Identity.Domain.Entities;

namespace MarGate.Identity.Application.Handlers.Identity.Commands.CreateUser;

public class CreateUserCommandHandler(IUnitOfWork unitOfWork) : CommandHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    private readonly IWriteRepository<User> _userWriteRepository = unitOfWork.GetWriteRepository<User>();

    public async override Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        var user = new User(
        request.FirstName,
        request.LastName,
        request.PhoneNumber != null ? new PhoneNumber(request.PhoneNumber) : null,
        new Address(request.AddressStreet, request.AddressCity, request.AddressCountry),
        new EmailAddress(request.EmailAddress),
        request.BirthDate,
        request.PasswordText,
        0m
    );

        var id = _userWriteRepository.Create(user);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateUserCommandResponse()
        {
            IsSuccess = true,
            UserId = id
        };

    }
}
