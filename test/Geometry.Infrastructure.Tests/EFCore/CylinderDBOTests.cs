using Geometry.Infrastructure.Persistence.EFCore;
using Xunit;

namespace Geometry.Infrastructure.Tests;

public class CylinderDBOTests
{
    [Fact]
    public void Properties_SetAndGet()
    {
        var DBO = new CylinderDBO
        {
            Id = Guid.NewGuid(),
            Radius = 2.5,
            Height = 9
        };

        Assert.Equal(2.5, DBO.Radius);
        Assert.Equal(9, DBO.Height);
    }
}
