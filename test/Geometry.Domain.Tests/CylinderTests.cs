using Geometry.Domain;
using Xunit;
namespace Geometry.Domain.Tests;
public class CylinderTests
{
    [Fact]
    public void Constructor_ValidValues_SetsProperties()
    {
        var cylinder = new Cylinder(2, 5);

        Assert.Equal(2, cylinder.Radius);
        Assert.Equal(5, cylinder.Height);
        Assert.NotEqual(Guid.Empty, cylinder.Id);
    }

    [Theory]
    [InlineData(0, 5)]
    [InlineData(-1, 5)]
    [InlineData(2, 0)]
    [InlineData(2, -1)]
    public void Constructor_InvalidValues_Throws(double radius, double height)
    {
        Assert.Throws<ArgumentException>(() => new Cylinder(radius, height));
    }

    [Fact]
    public void Update_ValidValues_UpdatesProperties()
    {
        var cylinder = new Cylinder(1, 1);
        cylinder.Update(3, 4);

        Assert.Equal(3, cylinder.Radius);
        Assert.Equal(4, cylinder.Height);
    }

    [Fact]
    public void Volume_ComputesCorrectly()
    {
        var cylinder = new Cylinder(2, 10);
        var expected = Math.PI * 2 * 2 * 10;

        Assert.Equal(expected, cylinder.Volume());
    }
}
