using AutoMapper;
using Moq;
using ShoppingListApp.Application.Abstractions.UnitOfWork;
using ShoppingListApp.Application.Exceptions;
using ShoppingListApp.Application.Features.ShoppingListFeatures.UpdateShoppingList;
using ShoppingListApp.Domain.Entities;
using System.Linq.Expressions;

namespace ShoppingListApp.UnitTests;

[TestClass]
public class UpdateShoppingListHandlerTests
{
    private Mock<IUnitOfWork> mockUnitOfWork;
    private Mock<IMapper> mockMapper;
    private UpdateShoppinListHandler handler;

    [TestInitialize]
    public void TestInitialize()
    {
        mockUnitOfWork = new Mock<IUnitOfWork>();
        mockMapper = new Mock<IMapper>();
        handler = new UpdateShoppinListHandler(mockMapper.Object, mockUnitOfWork.Object);
    }

    [TestMethod]
    public async Task Handle_ShouldUpdateShoppingList_WhenShoppingListExists()
    {
        // Arrange
        var shoppingList = new ShoppingList { ShoppingListID = 1 };
        var request = new UpdateShoppingListRequest(1,5,"June","2023",new List<ShoppingItem>());

        mockUnitOfWork.Setup(u => u.ShoppingListRepository.GetAsync(It.IsAny<Expression<Func<ShoppingList, bool>>>()))
            .ReturnsAsync(shoppingList);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        mockUnitOfWork.Verify(u => u.ShoppingListRepository.Update(It.IsAny<ShoppingList>()), Times.Once);
        mockUnitOfWork.Verify(u => u.CommitAsync(), Times.Once);
        Assert.AreEqual(shoppingList, result);
    }

    [TestMethod]
    public async Task Handle_ShouldThrowException_WhenShoppingListDoesNotExist()
    {
        // Arrange
        var request = new UpdateShoppingListRequest (1, 5, "June", "2023", new List<ShoppingItem>());

        mockUnitOfWork.Setup(u => u.ShoppingListRepository.GetAsync(It.IsAny<Expression<Func<ShoppingList, bool>>>()))
            .ReturnsAsync((ShoppingList)null);

        // Act & Assert
        await Assert.ThrowsExceptionAsync<ShoppingListNotFoundException>(() => handler.Handle(request, CancellationToken.None));
    }
}
