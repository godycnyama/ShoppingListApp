using AutoMapper;
using Moq;
using ShoppingListApp.Application.Abstractions.UnitOfWork;
using ShoppingListApp.Application.Common.DTO;
using ShoppingListApp.Application.Features.ShoppingListFeatures.CreateShoppingList;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.UnitTests;

[TestClass]
public class CreateShoppingListHandlerTests
{
    private Mock<IMapper> _mockMapper;
    private Mock<IUnitOfWork> _mockUnitOfWork;
    private CreateShoppingListHandler _handler;
    
    [TestInitialize]
    public void TestInitialize()
    {
        _mockMapper = new Mock<IMapper>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _handler = new CreateShoppingListHandler(_mockMapper.Object, _mockUnitOfWork.Object);
    }

    [TestMethod]
    public async Task Handle_ShouldCreateShoppingList()
    {
        // Arrange
        var request = new CreateShoppingListRequest("james.madon@hotmail.com", "June","2025", new List<ShoppingItemDTO>() );
        var shoppingList = new ShoppingList();
        _mockMapper.Setup(m => m.Map<ShoppingList>(request)).Returns(shoppingList);
        _mockUnitOfWork.Setup(u => u.ShoppingListRepository.AddAsync(shoppingList)).Returns(Task.CompletedTask);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.AreEqual(shoppingList, result);
        _mockMapper.Verify(m => m.Map<ShoppingList>(request), Times.Once);
        _mockUnitOfWork.Verify(u => u.ShoppingListRepository.AddAsync(shoppingList), Times.Once);
    }
}
