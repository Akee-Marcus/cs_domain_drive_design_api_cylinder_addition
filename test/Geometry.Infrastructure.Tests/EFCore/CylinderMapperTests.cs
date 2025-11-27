using Geometry.Domain;
using Geometry.Infrastructure.Persistence.EFCore;
using Xunit;

namespace Geometry.Infrastructure.Tests;

public class CylinderMapperTests
{
    [Fact]
    public void ToDBO_MapsCorrectly()
    {
        var cylinder = new Cylinder(3, 7);

        var dbo = CylinderMapper.ToDBO(cylinder);

        Assert.Equal(cylinder.Id, dbo.Id);
        Assert.Equal(3, dbo.Radius);
        Assert.Equal(7, dbo.Height);
    }

    [Fact]
    public void ToDomain_MapsCorrectly()
    {
        var id = Guid.NewGuid();
        var dbo = new CylinderDBO
        {
            Id = id,
            Radius = 4,
            Height = 8
        };

        var cylinder = CylinderMapper.ToDomain(dbo);

        Assert.Equal(id, cylinder.Id);
        Assert.Equal(4, cylinder.Radius);
        Assert.Equal(8, cylinder.Height);
    }
}
