namespace Geometry.Domain;

public interface ICylinderRepository
{
    Task<Cylinder?> GetAsync(Guid id);
    Task AddAsync(Cylinder cylinder);
    Task UpdateAsync(Cylinder cylinder);
    Task DeleteAsync(Guid id);
}
