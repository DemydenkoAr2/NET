namespace SelfTask_Dimensions;

public struct Vector3
{
    public float x;
    public float y;
    public float z;

    public Vector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    
    public static Vector3 zero = new Vector3(0, 0, 0);
    public static Vector3 one = new Vector3(1, 1, 1);
    public static Vector3 up = new Vector3(0, 1, 0);
    public static Vector3 down = new Vector3(0, -1, 0);
    public static Vector3 left = new Vector3(-1, 0, 0);
    public static Vector3 right = new Vector3(1, 0, 0);
    public static Vector3 forward = new Vector3(0, 0, 1);
    public static Vector3 back = new Vector3(0, 0, -1);
    
    public static Vector3 operator +(Vector3 a, Vector3 b) => new(a.x + b.x, a.y + b.y, a.z + b.z);
    public static Vector3 operator -(Vector3 a, Vector3 b) => new(a.x - b.x, a.y - b.y, a.z - b.z);
    public static Vector3 operator *(Vector3 a, float d) => new(a.x * d, a.y * d, a.z * d);
    public static Vector3 operator /(Vector3 a, float d) => new(a.x / d, a.y / d, a.z / d);

    public void GetPosition()
    {
        Console.WriteLine($"x: {x}, y: {y}, z: {z}");
    }
}