using System.Text.Json;

namespace Lesson4
{
	public class Vector3D(double x, double y, double z)
	{
		public double X { get; set; } = x;
		public double Y { get; set; } = y;
		public double Z { get; set; } = z;

		public double Magnitude() => Math.Sqrt(X * X + Y * Y + Z * Z);

		public static Vector3D operator +(Vector3D v1, Vector3D v2)
			=> new(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);

		public static Vector3D operator -(Vector3D v1, Vector3D v2)
			=> new(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);

		public static Vector3D operator *(Vector3D v, double scalar)
			=> new(v.X * scalar, v.Y * scalar, v.Z * scalar);

		public static Vector3D operator *(double scalar, Vector3D v)
			=> v * scalar;

		public static double operator *(Vector3D v1, Vector3D v2)
			=> v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;

		public static double AngleBetween(Vector3D v1, Vector3D v2)
		{
			double dot = v1 * v2;
			double magnitudes = v1.Magnitude() * v2.Magnitude();
			return Math.Acos(dot / magnitudes) * (180.0 / Math.PI);
		}

		public override string ToString()
			=> $"({X}, {Y}, {Z})";

		public void SaveToFile(string filePath)
		{
			var json = JsonSerializer.Serialize(this);
			File.WriteAllText(filePath, json);
		}

		public static Vector3D? LoadFromFile(string filePath)
		{
			var json = File.ReadAllText(filePath);
			return JsonSerializer.Deserialize<Vector3D>(json);
		}
	}

	public class Vector3DTest
	{
		public static void StartTest()
		{
			Vector3D v1 = new(3, 4, 5);
			Vector3D v2 = new(1, 2, 3);

			Console.WriteLine($"Vector 1: {v1}");
			Console.WriteLine($"Vector 2: {v2}");

			Vector3D sum = v1 + v2;
			Console.WriteLine($"Sum: {sum}");

			Vector3D diff = v1 - v2;
			Console.WriteLine($"Difference: {diff}");

			Vector3D scaled = v1 * 2;
			Console.WriteLine($"Scaled v1: {scaled}");

			double dotProduct = v1 * v2;
			Console.WriteLine($"Dot Product: {dotProduct}");

			double angle = Vector3D.AngleBetween(v1, v2);
			Console.WriteLine($"Angle between v1 and v2: {angle} degrees");

			string filePath = "vector.json";
			v1.SaveToFile(filePath);
			Console.WriteLine($"Vector saved to {filePath}");

			Vector3D? loadedVector = Vector3D.LoadFromFile(filePath);
			Console.WriteLine($"Loaded Vector: {loadedVector}");
		}
	}
}
