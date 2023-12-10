using AutoMapper;
using Moq;
using ShoppingListApp.Application.Abstractions.UnitOfWork;
using ShoppingListApp.Application.Exceptions;
using ShoppingListApp.Application.Features.ShoppingListFeatures.UpdateItemInShoppingList;
using ShoppingListApp.Domain.Entities;
using System.Linq.Expressions;

namespace ShoppingListApp.UnitTests;

[TestClass]
public class UpdateItemInShoppingListHandlerTests
{
    private Mock<IUnitOfWork> mockUnitOfWork;
    private Mock<IMapper> mockMapper;
    private UpdateItemInShoppingListHandler handler;

    [TestInitialize]
    public void TestInitialize()
    {
        mockUnitOfWork = new Mock<IUnitOfWork>();
        mockMapper = new Mock<IMapper>();
        handler = new UpdateItemInShoppingListHandler(mockMapper.Object, mockUnitOfWork.Object);
    }

    [TestMethod]
    public async Task Handle_ShoppingListNotFound_ThrowsException()
    {
        // Arrange
        var request = new UpdateItemInShoppingListRequest(1, "james.madon@hotmail.com", new ShoppingItem());

        // Act & Assert
        await Assert.ThrowsExceptionAsync<ShoppingListNotFoundException>(() => handler.Handle(request, CancellationToken.None));
    }

    [TestMethod]
    public async Task Handle_ShoppingItemNotFound_ThrowsException()
    {
        // Arrange
        var shoppingList = new ShoppingList { UserName = "james.madon@hotmail.com", ShoppingListID = 1, ShoppingItems = new List<ShoppingItem>() };
        mockUnitOfWork.Setup(u => u.ShoppingListRepository.Get(It.IsAny<Expression<Func<ShoppingList, bool>>>())).Returns(shoppingList);
        var request = new UpdateItemInShoppingListRequest(1, "james.madon@hotmail.com", new ShoppingItem { ShoppingItemID = 2 });

        // Act & Assert
        await Assert.ThrowsExceptionAsync<ShoppingItemNotFoundException>(() => handler.Handle(request, CancellationToken.None));
    }

    [TestMethod]
    public async Task Handle_ValidRequest_UpdatesShoppingList()
    {
        // Arrange
        var shoppingItem = new ShoppingItem { ShoppingItemID = 2 };
        var shoppingList = new ShoppingList { UserName = "james.madon@hotmail.com", ShoppingListID = 1, ShoppingItems = new List<ShoppingItem> { shoppingItem } };
        mockUnitOfWork.Setup(u => u.ShoppingListRepository.Get(It.IsAny<Expression<Func<ShoppingList, bool>>>())).Returns(shoppingList);
        var request = new UpdateItemInShoppingListRequest (1, "james.madon@hotmail.com", new ShoppingItem { ShoppingItemID = 2 });

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        mockUnitOfWork.Verify(u => u.ShoppingListRepository.Update(shoppingList), Times.Once);
        mockUnitOfWork.Verify(u => u.CommitAsync(), Times.Once);
        Assert.AreEqual(shoppingList, result);
    }
}

