using MarGate.Core.CQRS.Command;
using MarGate.Core.Persistence.Repository;
using MarGate.Core.Persistence.UnitOfWork;
using MarGate.Identity.Domain.Entities;

namespace MarGate.Identity.Application.Handlers.Identity.Commands.UpdateUser;

public class UpdateUserCommandHandler(IUnitOfWork unitOfWork) : CommandHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
{
    private readonly IWriteRepository<User> _userWriteRepository = unitOfWork.GetWriteRepository<User>();

    public async override Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _userWriteRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        user.SetFirstName(request.FirstName);
        user.SetLastName(request.LastName);
        user.SetPhoneNumber(new PhoneNumber(request.PhoneNumber));
        user.SetAddress(new Address(request.AddressStreet, request.AddressCity, request.AddressCountry));
        user.SetEmailAddress(new EmailAddress(request.EmailAddress));
        user.SetBirthDate(request.BirthDate);
        user.SetPasswordText(request.PasswordText);

        var isSuccess = _userWriteRepository.Update(user);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new UpdateUserCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
