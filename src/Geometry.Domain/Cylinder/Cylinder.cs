namespace Geometry.Domain;

public class Cylinder
{
    public Guid Id { get; private set; }
    public double Radius { get; private set; }
    public double Height { get; private set; }

    public Cylinder(double radius, double height)
    {
        if (radius <= 0)
            throw new ArgumentException("Radius must be greater than zero.");

        if (height <= 0)
            throw new ArgumentException("Height must be greater than zero.");

        Id = Guid.NewGuid();
        Radius = radius;
        Height = height;
    }

    public double Volume() => Math.PI * Radius * Radius * Height;

    public void Update(double radius, double height)
    {
        if (radius <= 0 || height <= 0)
            throw new ArgumentException("Dimensions must be greater than zero.");

        Radius = radius;
        Height = height;
    }

    // Used ONLY by the repository when rehydrating from the database.
    public void SetId(Guid id)
    {
        Id = id;
    }
}
