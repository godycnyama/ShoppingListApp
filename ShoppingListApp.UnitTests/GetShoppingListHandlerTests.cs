using AutoMapper;
using Moq;
using ShoppingListApp.Application.Abstractions.UnitOfWork;
using ShoppingListApp.Application.Features.ShoppingListFeatures.CreateShoppingList;
using ShoppingListApp.Application.Features.ShoppingListFeatures.GetShoppingList;
using ShoppingListApp.Domain.Entities;

namespace ShoppingListApp.UnitTests;

[TestClass]
public class GetShoppingListHandlerTests
{
    private Mock<IUnitOfWork> mockUnitOfWork;
    private Mock<IMapper> mockMapper;
    private GetShoppingListHandler getShoppingListHandler;

    [TestInitialize]
    public void TestInitialize()
    {
        mockUnitOfWork = new Mock<IUnitOfWork>();
        mockMapper = new Mock<IMapper>();
        getShoppingListHandler = new GetShoppingListHandler(mockUnitOfWork.Object);
    }

    [TestMethod]
    public async Task Handle_ShouldReturnShoppingList()
    {
        // Arrange
        var request = new GetShoppingListRequest(1, "james.madon@hotmail.com");
        var shoppingList = new ShoppingList();
        mockMapper.Setup(m => m.Map<ShoppingList>(request)).Returns(shoppingList);
        mockUnitOfWork.Setup(u => u.ShoppingListRepository.AddAsync(shoppingList));

        // Act
        var result = await getShoppingListHandler.Handle(request, CancellationToken.None);

        // Assert
        Assert.AreEqual(shoppingList, result);
        mockUnitOfWork.Verify(u => u.ShoppingListRepository.AddAsync(shoppingList), Times.Once);
    }
}
