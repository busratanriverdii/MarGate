using MarGate.Core.CQRS.Command;
using MarGate.Identity.Domain.Entities;
using MarGate.Core.UnitOfWork.Repository;
using MarGate.Core.UnitOfWork.UnitOfWork;

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
        user.SetPhoneNumber(request.PhoneNumber);
        user.SetAddress(request.Address);
        user.SetEmailAddress(request.EmailAddress);
        user.SetBirthDate(request.BirthDate);
        user.SetPasswordText(request.PasswordText);

        var isSuccess = _userWriteRepository.Update(user);

        return new UpdateUserCommandResponse()
        {
            IsSuccess = isSuccess
        };
    }
}
