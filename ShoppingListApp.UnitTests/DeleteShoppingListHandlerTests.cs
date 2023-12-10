using AutoMapper;
using Moq;
using ShoppingListApp.Application.Abstractions.UnitOfWork;
using ShoppingListApp.Application.Common.Responses;
using ShoppingListApp.Application.Exceptions;
using ShoppingListApp.Application.Features.ShoppingListFeatures.DeleteShoppingList;
using ShoppingListApp.Domain.Entities;
using System.Linq.Expressions;

namespace ShoppingListApp.UnitTests;

[TestClass]
public class DeleteShoppingListHandlerTests
{
    private Mock<IUnitOfWork> mockUnitOfWork;
    private Mock<IMapper> mockMapper;
    private DeleteShoppingListHandler deleteShoppingListHandler;

    [TestInitialize]
    public void TestInitialize()
    {
        mockUnitOfWork = new Mock<IUnitOfWork>();
        mockMapper = new Mock<IMapper>();
        deleteShoppingListHandler = new DeleteShoppingListHandler(mockMapper.Object, mockUnitOfWork.Object);
    }

    [TestMethod]
    public async Task Handle_ShouldReturnMessageResponse_WhenShoppingListIsFoundAndDeleted()
    {
        // Arrange
        var shoppingList = new ShoppingList { ShoppingListID = 1, UserName = "james.madon@hotmail.com" };
        var request = new DeleteShoppingListRequest(1,1);
        mockUnitOfWork.Setup(u => u.ShoppingListRepository.GetAsync(It.IsAny<Expression<Func<ShoppingList, bool>>>())).ReturnsAsync(shoppingList);

        // Act
        var result = await deleteShoppingListHandler.Handle(request, CancellationToken.None);

        // Assert
        Assert.IsInstanceOfType(result, typeof(MessageResponse));
        Assert.AreEqual($"Shopping list with id: {request.ShoppingListID} deleted successfully", result.Message);
        mockUnitOfWork.Verify(u => u.ShoppingListRepository.Remove(shoppingList), Times.Once);
        mockUnitOfWork.Verify(u => u.CommitAsync(), Times.Once);
    }

    [TestMethod]
    public async Task Handle_ShouldThrowShoppingListNotFoundException_WhenShoppingListIsNotFound()
    {
        // Arrange
        var request = new DeleteShoppingListRequest (1, 1);
        mockUnitOfWork.Setup(u => u.ShoppingListRepository.GetAsync(It.IsAny<Expression<Func<ShoppingList, bool>>>())).ReturnsAsync((ShoppingList)null);

        // Act & Assert
        await Assert.ThrowsExceptionAsync<ShoppingListNotFoundException>(() => deleteShoppingListHandler.Handle(request, CancellationToken.None));
    }
}
