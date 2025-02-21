using System;

partial class Program
{
	static void Main()
	{
		PrintPrime();
	}

	static void PrintPrime()
	{
		Console.Write("����������: ");
		int max = int.Parse(Console.ReadLine());
		Console.Write("����������: ");
		int min = int.Parse(Console.ReadLine());
		int count = 0;
		if (max <= min)
		{
			Console.WriteLine("�������");
		}
		for (int i = min + 1; i < max; i++)
		{
			if (IsPrime(i))
			{
				Console.Write(i + "   ");
				count++;
				if (count % 10 == 0)
				{
					Console.WriteLine();
				}
			}
		}
		Console.WriteLine();
	}

	static bool IsPrime(int n)
	{
		if (n < 2) return false;
		for (int i = 2; i * i <= n; i++)
		{
			if (n % i == 0)
			{
				return false;
			}
		}
		return true;
	}
}
