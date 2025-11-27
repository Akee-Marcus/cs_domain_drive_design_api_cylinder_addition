using Geometry.Domain;
using Geometry.Infrastructure.Persistence.EFCore;

public class CylinderRepository : ICylinderRepository
{
    private readonly GeometryDbContext _db;

    public CylinderRepository(GeometryDbContext db)
    {
        _db = db;
    }

    public async Task<Cylinder?> GetAsync(Guid id)
    {
        var dbo = await _db.Cylinders.FindAsync(id);
        return dbo is null ? null : CylinderMapper.ToDomain(dbo);
    }

    public async Task AddAsync(Cylinder cylinder)
    {
        var dbo = CylinderMapper.ToDBO(cylinder);
        _db.Cylinders.Add(dbo);

        await _db.SaveChangesAsync();

        // Set generated ID (EF may override Guid if DB configured that way)
        cylinder.SetId(dbo.Id);
    }

    public async Task UpdateAsync(Cylinder cylinder)
    {
        var dbo = CylinderMapper.ToDBO(cylinder);
        _db.Cylinders.Update(dbo);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var dbo = await _db.Cylinders.FindAsync(id);
        if (dbo is null) return;

        _db.Cylinders.Remove(dbo);
        await _db.SaveChangesAsync();
    }
}
