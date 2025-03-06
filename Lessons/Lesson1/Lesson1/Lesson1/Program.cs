using Lesson1.OOP;
using System.Text;

public class Program
{
	public static void Main()  // точка входа в программу, программа стартует с этой функции (метода)
	{
		Console.OutputEncoding = Encoding.UTF8;

		// FirstExample.Test();

		// SimplePolymorphysm.Test();

		//var person = new Person
		//{
		//	TestInfo = "demo"
		//};
		//Console.WriteLine(person.TestInfo);
		// person.TestInfo = "qqqq";

		//Console.WriteLine(InvoiceTypes.Urgent);
		//var result = MathOperations.Add(1, 4);
		//Console.WriteLine(result);

		//var pers = new PersonV3(30);
		//pers.CheckRetirementStatus(new PersonV3(44));

		//var user = new PersonV4();
		//string name = "Vasya";
		//int anyNumber = 123;
		//user.Deconstruct(out name, out int age, ref anyNumber, anyNumber);
		//Console.WriteLine($"{name} - {age}");
		//Console.WriteLine(anyNumber);


		//// упаковка и распаковка данных
		//var number = 10;
		//Console.WriteLine(number);
		//object my_number = number; // упаковка
		//Console.WriteLine(my_number);
		//var number_from_object = (int)my_number; // распаковка
		//Console.WriteLine(number_from_object);

		//// распаковка (можем распаковать только в исходный значимый тип данных)
		//var number_from_object_1 = (sbyte)my_number;
		//Console.WriteLine(number_from_object_1);

		/*
		Типи значень:

		Цілочисленні типи (byte, sbyte, short, ushort, int, uint, long, ulong)

		Типи з плаваючою комою (float, double)

		Тип decimal

		Тип bool

		Тип char

		Перерахування enum

		Структури (struct)

		Посилальні типи: (ссылочные типы данных)

		Тип object

		Тип string

		Класи (class)

		Інтерфейси (interface)

		Делегати (delegate)
		*/
	}
}