using Bogus;
using FluentAssertions;
using MarGate.Core.Common.Exception;
using MarGate.Core.UnitOfWork.Repository;
using MarGate.Core.UnitOfWork.UnitOfWork;
using MarGate.Identity.Application.Handlers.Identity.Queries.GetUserById;
using MarGate.Identity.Domain.Entities;
using Moq;
using System.Linq.Expressions;

namespace MarGate.Identity.Application.Tests.Handlers.UserTests;

public class GetUserByIdTests
{
    [Fact]
    public async Task Handle_ShouldReturnCorrectUser_WhenUserExists()
    {
        // Arrange
        var userId = 1L;
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockUserReadRepository = new Mock<IReadRepository<User>>();

        var faker = new Faker<User>()
    .RuleFor(u => u.Id, userId)
    .RuleFor(u => u.FirstName, f => f.Name.FirstName())
    .RuleFor(u => u.LastName, f => f.Name.LastName())
    .RuleFor(u => u.EmailAddress, f => f.Internet.Email())
    .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber())
    .RuleFor(u => u.Address, f => f.Address.FullAddress())
    .RuleFor(u => u.Balance, f => f.Finance.Amount())
    .RuleFor(u => u.BirthDate, f => f.Date.Past(24));

        var fakeUser = faker.Generate();

        mockUserReadRepository.Setup(x => x.FirstOrDefaultAsync(
            It.IsAny<Expression<Func<User, bool>>>(),
            It.IsAny<CancellationToken>())).ReturnsAsync(fakeUser);

        mockUnitOfWork
            .Setup(uow => uow.GetReadRepository<User>())
            .Returns(mockUserReadRepository.Object);

        var handler = new GetUserByIdQueryHandler(mockUnitOfWork.Object);
        var request = new GetUserByIdQueryRequest { Id = userId };

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        fakeUser.Id.Should().Be(result.Id);
        fakeUser.FirstName.Should().Be(result.FirstName);
        fakeUser.LastName.Should().Be(result.LastName);
        fakeUser.EmailAddress.Should().Be(result.EmailAddress);
        fakeUser.PhoneNumber.Should().Be(result.PhoneNumber);
        fakeUser.Balance.Should().Be(result.Balance);
        fakeUser.BirthDate.Should().Be(result.BirthDate);
    }

    [Fact]
    public async Task Handle_ShouldReturnNull_WhenUserDoesNotExist()
    {
        // Arrange
        var userId = 1L;
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockUserReadRepository = new Mock<IReadRepository<User>>();

        mockUserReadRepository.Setup(x => x.FirstOrDefaultAsync(
            It.IsAny<Expression<Func<User, bool>>>(),
            It.IsAny<CancellationToken>()));

        mockUnitOfWork
            .Setup(uow => uow.GetReadRepository<User>())
            .Returns(mockUserReadRepository.Object);

        var handler = new GetUserByIdQueryHandler(mockUnitOfWork.Object);

        var request = new GetUserByIdQueryRequest { Id = userId };

        // Act
        Func<Task> handle = async () => await handler.Handle(request, default);

        // Assert
        await handle.Should().ThrowAsync<BusinessException>()
            .WithMessage($"user not found with id :{request.Id}");
    }
}
