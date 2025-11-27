using Geometry.Domain;
using Geometry.Infrastructure.Persistence.EFCore;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Geometry.Infrastructure.Tests;

public class CylinderRepositoryTests
{
    private GeometryDbContext CreateDb()
    {
        var options = new DbContextOptionsBuilder<GeometryDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new GeometryDbContext(options);
    }

    [Fact]
    public async Task AddAsync_SavesCylinder()
    {
        var db = CreateDb();
        var repo = new CylinderRepository(db);

        var cylinder = new Cylinder(2, 3);

        await repo.AddAsync(cylinder);

        var saved = await db.Cylinders.FindAsync(cylinder.Id);

        Assert.NotNull(saved);
        Assert.Equal(2, saved!.Radius);
    }

    [Fact]
    public async Task GetAsync_ReturnsCylinder()
    {
        var db = CreateDb();
        var repo = new CylinderRepository(db);

        var cylinder = new Cylinder(3, 4);
        db.Cylinders.Add(CylinderMapper.ToDBO(cylinder));
        await db.SaveChangesAsync();

        var result = await repo.GetAsync(cylinder.Id);

        Assert.NotNull(result);
        Assert.Equal(3, result!.Radius);
    }

    [Fact]
    public async Task DeleteAsync_RemovesCylinder()
    {
        var db = CreateDb();
        var repo = new CylinderRepository(db);

        var cylinder = new Cylinder(3, 4);
        db.Cylinders.Add(CylinderMapper.ToDBO(cylinder));
        await db.SaveChangesAsync();

        await repo.DeleteAsync(cylinder.Id);

        var deleted = await db.Cylinders.FindAsync(cylinder.Id);

        Assert.Null(deleted);
    }
}
