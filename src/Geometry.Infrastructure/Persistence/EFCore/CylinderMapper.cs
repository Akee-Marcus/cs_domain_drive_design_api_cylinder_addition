using Geometry.Domain;
using Geometry.Infrastructure.Persistence.EFCore;

/// <summary>
/// Mapper class for converting between Cylinder domain entities and CylinderDBO database objects.
/// Provides bidirectional mapping functionality for persistence operations.
/// </summary>
public static class CylinderMapper
{
    /// <summary>
    /// Maps a Cylinder domain entity to a CylinderDBO database object.
    /// </summary>
    public static CylinderDBO ToDBO(Cylinder cylinder)
    {
        if (cylinder == null)
            throw new ArgumentNullException(nameof(cylinder));

        return new CylinderDBO
        {
            Id = cylinder.Id,
            Radius = cylinder.Radius,
            Height = cylinder.Height
        };
    }

    /// <summary>
    /// Maps a CylinderDBO database object to a Cylinder domain entity.
    /// </summary>
    public static Cylinder ToDomain(CylinderDBO cylinderDBO)
    {
        if (cylinderDBO == null)
            throw new ArgumentNullException(nameof(cylinderDBO));

        // Use the domain constructor
        var cylinder = new Cylinder(cylinderDBO.Radius, cylinderDBO.Height);

        // Set ID via domain method (cannot use object initializer since setter is private)
        cylinder.SetId(cylinderDBO.Id);

        return cylinder;
    }
}
