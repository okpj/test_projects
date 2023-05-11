namespace MatrixTestApp.NEW;

public struct Vector
{
    public int X;
    public int Y;

    public Vector(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static Vector operator +(Vector a, Vector b) => new Vector(a.X + b.X, a.Y + b.Y);

    public static Vector operator *(Vector a, Vector b) => new Vector(a.X * b.X, a.Y * b.Y);
}
