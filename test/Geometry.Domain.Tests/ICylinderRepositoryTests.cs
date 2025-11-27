using Geometry.Domain;
using Moq;
using Xunit;
namespace Geometry.Domain.Tests;
public class ICylinderRepositoryTests
{
    [Fact]
    public async Task GetAsync_CallsRepositoryMethod()
    {
        var id = Guid.NewGuid();
        var mock = new Mock<ICylinderRepository>();

        mock.Setup(r => r.GetAsync(id))
            .ReturnsAsync(new Cylinder(2, 3));

        var result = await mock.Object.GetAsync(id);

        Assert.NotNull(result);
        Assert.Equal(2, result!.Radius);
    }
}
