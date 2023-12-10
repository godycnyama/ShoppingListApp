using AutoMapper;
using Moq;
using ShoppingListApp.Application.Abstractions.UnitOfWork;
using ShoppingListApp.Application.Exceptions;
using ShoppingListApp.Application.Features.ShoppingListFeatures.DeleteItemFromShoppingList;
using ShoppingListApp.Domain.Entities;
using System.Linq.Expressions;

namespace ShoppingListApp.UnitTests;

[TestClass]
public class DeleteItemFromShoppingListHandlerTests
{
    private Mock<IUnitOfWork> mockUnitOfWork;
    private Mock<IMapper> mockMapper;
    private DeleteItemFromShoppingListHandler handler;

    [TestInitialize]
    public void TestInitialize()
    {
        mockUnitOfWork = new Mock<IUnitOfWork>();
        mockMapper = new Mock<IMapper>();
        handler = new DeleteItemFromShoppingListHandler(mockMapper.Object, mockUnitOfWork.Object);
    }

    [TestMethod]
    [ExpectedException(typeof(ShoppingListNotFoundException))]
    public async Task Handle_ShoppingListNotFound_ThrowsException()
    {
        // Arrange
        var request = new DeleteItemFromShoppingListRequest (1, "james.madon@hotmail.com", 1);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);
    }

    [TestMethod]
    [ExpectedException(typeof(ShoppingItemNotFoundException))]
    public async Task Handle_ShoppingItemNotFound_ThrowsException()
    {
        // Arrange
        var request = new DeleteItemFromShoppingListRequest (1, "james.madon@hotmail.com", 1);
        var shoppingList = new ShoppingList { UserName = "james.madon@hotmail.com", ShoppingListID = 1, ShoppingItems = new List<ShoppingItem>() };
        mockUnitOfWork.Setup(u => u.ShoppingListRepository.Get(It.IsAny<Expression<Func<ShoppingList, bool>>>())).Returns(shoppingList);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);
    }

    [TestMethod]
    public async Task Handle_ValidRequest_RemovesItemFromList()
    {
        // Arrange
        var request = new DeleteItemFromShoppingListRequest(1, "james.madon@hotmail.com", 1);
        var shoppingItem = new ShoppingItem { ShoppingItemID = 1 };
        var shoppingList = new ShoppingList { UserName = "james.madon@hotmail.com", ShoppingListID = 1, ShoppingItems = new List<ShoppingItem> { shoppingItem } };
        mockUnitOfWork.Setup(u => u.ShoppingListRepository.Get(It.IsAny<Expression<Func<ShoppingList, bool>>>())).Returns(shoppingList);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.IsFalse(result.ShoppingItems.Contains(shoppingItem));
        mockUnitOfWork.Verify(u => u.ShoppingListRepository.Update(shoppingList), Times.Once);
        mockUnitOfWork.Verify(u => u.CommitAsync(), Times.Once);
    }
}
