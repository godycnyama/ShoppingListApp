using Moq;
using ShoppingListApp.Application.Abstractions.UnitOfWork;
using ShoppingListApp.Application.Exceptions;
using ShoppingListApp.Application.Features.ShoppingListFeatures.GetShoppingLists;
using ShoppingListApp.Domain.Entities;
using System.Linq.Expressions;

namespace ShoppingListApp.UnitTests;

[TestClass]
public class GetShoppingListsHandlerTests
{
    private Mock<IUnitOfWork> _mockUnitOfWork;
    private GetShoppingListsHandler _handler;

    [TestInitialize]
    public void TestInitialize()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _handler = new GetShoppingListsHandler(_mockUnitOfWork.Object);
    }

    [TestMethod]
    public async Task Handle_ShouldReturnShoppingLists_WhenShoppingListsExist()
    {
        // Arrange
        var shoppingLists = new List<ShoppingList> { new ShoppingList(), new ShoppingList() };
        _mockUnitOfWork.Setup(u => u.ShoppingListRepository.GetAllAsync(It.IsAny<Expression<Func<ShoppingList, bool>>>()))
            .ReturnsAsync(shoppingLists);

        var request = new GetShoppingListsRequest("james.madon@hotmail.com");

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(shoppingLists.Count, result.Count());
    }

    [TestMethod]
    public async Task Handle_ShouldThrowShoppingListsNotFoundException_WhenShoppingListsDoNotExist()
    {
        // Arrange
        _mockUnitOfWork.Setup(u => u.ShoppingListRepository.GetAllAsync(It.IsAny<Expression<Func<ShoppingList, bool>>>()))
            .ReturnsAsync((IEnumerable<ShoppingList>)null);

        var request = new GetShoppingListsRequest("james.madon@hotmail.com");

        // Act & Assert
        await Assert.ThrowsExceptionAsync<ShoppingListsNotFoundException>(() => _handler.Handle(request, CancellationToken.None));
    }
}

