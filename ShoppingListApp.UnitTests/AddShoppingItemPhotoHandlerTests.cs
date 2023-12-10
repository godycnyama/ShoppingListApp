using AutoMapper;
using Moq;
using ShoppingListApp.Application.Abstractions.Services;
using ShoppingListApp.Application.Abstractions.UnitOfWork;
using ShoppingListApp.Application.Exceptions;
using ShoppingListApp.Application.Features.ShoppingListFeatures.AddShoppingItemPhoto;
using ShoppingListApp.Domain.Entities;
using System.Linq.Expressions;

namespace ShoppingListApp.UnitTests;

[TestClass]
public class AddShoppingItemPhotoHandlerTests
{
    private Mock<IUnitOfWork> mockUnitOfWork;
    private Mock<IMapper> mockMapper;
    private Mock<IFileService> mockFileService;
    private AddShoppingItemPhotoHandler handler;

    [TestInitialize]
    public void TestInitialize()
    {
        mockUnitOfWork = new Mock<IUnitOfWork>();
        mockMapper = new Mock<IMapper>();
        mockFileService = new Mock<IFileService>();
        handler = new AddShoppingItemPhotoHandler(mockMapper.Object, mockUnitOfWork.Object, mockFileService.Object);
    }

    [TestMethod]
    public async Task Handle_ShoppingListNotFound_ThrowsException()
    {
        // Arrange
        var request = new AddShoppingItemPhotoRequest(1, "james.madon@hotmail.com", 1, null);

        // Act & Assert
        await Assert.ThrowsExceptionAsync<ShoppingListNotFoundException>(() => handler.Handle(request, CancellationToken.None));
    }

    [TestMethod]
    public async Task Handle_ShoppingItemNotFound_ThrowsException()
    {
        // Arrange
        var request = new AddShoppingItemPhotoRequest(1, "james.madon@hotmail.com", 1, null);
        var shoppingList = new ShoppingList { UserName = "james.madon@hotmail.com", ShoppingListID = 1, ShoppingItems = new List<ShoppingItem>() };
        mockUnitOfWork.Setup(u => u.ShoppingListRepository.Get(It.IsAny<Expression<Func<ShoppingList, bool>>>())).Returns(shoppingList);

        // Act & Assert
        await Assert.ThrowsExceptionAsync<ShoppingItemNotFoundException>(() => handler.Handle(request, CancellationToken.None));
    }

    [TestMethod]
    public async Task Handle_ValidRequest_UpdatesShoppingList()
    {
        // Arrange
        var request = new AddShoppingItemPhotoRequest(1, "james.madon@hotmail.com", 1, null);
        var shoppingItem = new ShoppingItem { ShoppingItemID = 1 };
        var shoppingList = new ShoppingList { UserName = "james.madon@hotmail.com", ShoppingListID = 1, ShoppingItems = new List<ShoppingItem> { shoppingItem } };
        mockUnitOfWork.Setup(u => u.ShoppingListRepository.Get(It.IsAny<Expression<Func<ShoppingList, bool>>>())).Returns(shoppingList);
        mockFileService.Setup(f => f.UploadFile(request.File)).ReturnsAsync("filename");

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.AreEqual("filename", shoppingItem.PhotoFileName);
        mockUnitOfWork.Verify(u => u.ShoppingListRepository.Update(shoppingList), Times.Once);
        mockUnitOfWork.Verify(u => u.CommitAsync(), Times.Once);
    }
}
