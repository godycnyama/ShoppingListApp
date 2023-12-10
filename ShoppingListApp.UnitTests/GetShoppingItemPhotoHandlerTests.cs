using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShoppingListApp.Application.Features.ShoppingListFeatures.GetShoppingItemPhoto;
using ShoppingListApp.Application.Abstractions.Services;
using ShoppingListApp.Application.Common.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingListApp.UnitTests;

[TestClass]
public class GetShoppingItemPhotoHandlerTests
{
    private Mock<IFileService> _mockFileService;
    private GetShoppingItemPhotoHandler _handler;

    [TestInitialize]
    public void TestInitialize()
    {
        _mockFileService = new Mock<IFileService>();
        _handler = new GetShoppingItemPhotoHandler(_mockFileService.Object);
    }

    [TestMethod]
    public async Task Handle_ShouldReturnFileResponse_WhenCalledWithValidRequest()
    {
        // Arrange
        var request = new GetShoppingItemPhotoRequest("test.jpg");
        var expectedResponse = new FileResponse { FileName = "test.jpg"};
        _mockFileService.Setup(fs => fs.GetFile(request.FileName)).ReturnsAsync(expectedResponse);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.AreEqual(expectedResponse, result);
        _mockFileService.Verify(fs => fs.GetFile(request.FileName), Times.Once);
    }
}
