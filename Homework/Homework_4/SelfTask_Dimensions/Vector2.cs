namespace SelfTask_Dimensions;

public struct Vector2
{
    public float x;
    public float y;

    public Vector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public static Vector2 zero => new Vector2(0, 0);
    public static Vector2 one => new Vector2(1, 1);
    public static Vector2 up => new Vector2(0, 1);
    public static Vector2 right => new Vector2(1, 0);

    public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.x + b.x, a.y + b.y);
    public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.x - b.x, a.y - b.y);
    public static Vector2 operator *(Vector2 a, Vector2 b) => new Vector2(a.x * b.x, a.y * b.y);
    public static Vector2 operator /(Vector2 a, float b) => new Vector2(a.x / b, a.y / b);

    public void GetPosition()
    {
        Console.WriteLine($"x: {x}, y: {y}");
    }
}