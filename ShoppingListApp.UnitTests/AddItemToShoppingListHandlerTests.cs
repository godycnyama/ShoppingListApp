using AutoMapper;
using Moq;
using ShoppingListApp.Application.Abstractions.UnitOfWork;
using ShoppingListApp.Application.Common.DTO;
using ShoppingListApp.Application.Exceptions;
using ShoppingListApp.Application.Features.ShoppingListFeatures.AddItemToShoppingList;
using ShoppingListApp.Domain.Entities;
using System.Linq.Expressions;

namespace ShoppingListApp.UnitTests;

[TestClass]
public class AddItemToShoppingListHandlerTests
{

    private Mock<IUnitOfWork> mockUnitOfWork;
    private Mock<IMapper> mockMapper;
    private AddItemToShoppingListHandler handler;
    private ShoppingItemDTO shoppingItemDTO;

    [TestInitialize]
    public void TestInitialize()
    {
        mockUnitOfWork = new Mock<IUnitOfWork>();
        mockMapper = new Mock<IMapper>();
        handler = new AddItemToShoppingListHandler(mockMapper.Object, mockUnitOfWork.Object);
        shoppingItemDTO = new ShoppingItemDTO
        {
            Cost = 300,
            Currency = "R",
            Name = "test",
            Quantity = 1
        };
    }

    [TestMethod]
    public async Task Handle_ShouldThrowException_WhenShoppingListNotFound()
    {
        // Arrange
        var request = new AddItemToShoppingListRequest(1, "james.madon@hotmail.com", shoppingItemDTO);

        // Act & Assert
        await Assert.ThrowsExceptionAsync<ShoppingListNotFoundException>(() => handler.Handle(request, CancellationToken.None));
    }

    [TestMethod]
    public async Task Handle_ShouldAddItemToShoppingList_WhenShoppingListFound()
    {
        // Arrange
        List<ShoppingItem> shoppingItems = new();
        shoppingItems.Add(new ShoppingItem { Name = "Bathing Soap", Quantity = 1, Cost = 50, Currency = "R", PhotoFileName = "Soap.png", ShoppingItemID = 1, ShoppingListID = 1 });
        var request = new AddItemToShoppingListRequest(1, "james.madon@hotmail.com", shoppingItemDTO);
        var shoppingList = new ShoppingList
        {
            UserName = "james.madon@hotmail.com",
            ShoppingListID = 1,
            ShoppingItems = shoppingItems,
            Month = "May",
            Year = "2023"
        };
        mockUnitOfWork.Setup(u => u.ShoppingListRepository.Get(It.IsAny<Expression<Func<ShoppingList, bool>>>())).Returns(shoppingList);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.AreEqual(1, result.ShoppingItems.Count);
        mockUnitOfWork.Verify(u => u.CommitAsync(), Times.Once);
    }
}