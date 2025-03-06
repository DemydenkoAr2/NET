namespace Lesson1.OOP
{
	// интерфейс IGraphic
	interface IGraphic
	{
		void ShowText(string text);
	}

	// класс ConsoleApp
	class ConsoleApp : IGraphic
	{
		public void ShowText(string text)
		{
			Console.WriteLine("Draw text " + text + " in console application");
		}
	}

	// класс Phone
	class Phone : IGraphic
	{
		public void ShowText(string text)
		{
			Console.WriteLine("Draw text " + text + " on the phone");
		}
	}

	public static class SimplePolymorphysm
	{
		public static void Test()
		{
			IGraphic graphic = new Phone();
			graphic.ShowText("Hello");
			graphic = new ConsoleApp();
			graphic.ShowText("Hello");
		}
	}
}
