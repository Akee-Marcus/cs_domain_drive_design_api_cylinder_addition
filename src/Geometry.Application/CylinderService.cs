using Geometry.Domain;

public class CylinderService
{
    private readonly ICylinderRepository _repo;

    public CylinderService(ICylinderRepository repo)
    {
        _repo = repo;
    }

    public async Task<Cylinder> CreateAsync(double radius, double height)
    {
        var cylinder = new Cylinder(radius, height);
        await _repo.AddAsync(cylinder);
        return cylinder;
    }

    public Task<Cylinder?> GetAsync(Guid id) => _repo.GetAsync(id);

    public async Task UpdateAsync(Guid id, double radius, double height)
    {
        var cylinder = await _repo.GetAsync(id)
            ?? throw new ArgumentException("Cylinder not found.");

        cylinder.Update(radius, height);
        await _repo.UpdateAsync(cylinder);
    }

    public Task DeleteAsync(Guid id) => _repo.DeleteAsync(id);
}
