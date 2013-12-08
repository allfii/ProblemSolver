/*
B. Spreadsheets
time limit per test10 seconds
memory limit per test64 megabytes
inputstandard input
outputstandard output
In the popular spreadsheets systems (for example, in Excel) the following numeration of columns is used. The first column has number A, the second — number B, etc. till column 26 that is marked by Z. Then there are two-letter numbers: column 27 has number AA, 28 — AB, column 52 is marked by AZ. After ZZ there follow three-letter numbers, etc.

The rows are marked by integer numbers starting with 1. The cell name is the concatenation of the column and the row numbers. For example, BC23 is the name for the cell that is in column 55, row 23.

Sometimes another numeration system is used: RXCY, where X and Y are integer numbers, showing the column and the row numbers respectfully. For instance, R23C55 is the cell from the previous example.

Your task is to write a program that reads the given sequence of cell coordinates and produce each item written according to the rules of another numeration system.

Input
The first line of the input contains integer number n (1?=?n?=?105), the number of coordinates in the test. Then there follow n lines, each of them contains coordinates. All the coordinates are correct, there are no cells with the column and/or the row numbers larger than 106 .

Output
Write n lines, each line should contain a cell coordinates in the other numeration system.

Sample test(s)
input
2
R23C55
BC23
output
BC23
R23C55
*/
using System;
public class solution
{
	public static void type1(string c, string r)
	{ // input alphabet and number
		if (c.Length > 1){
			int value=0;
			for(int i=0;i<c.Length;i++){
				value += (((int)c[i]-64) * ((int)Math.Pow(26,((c.Length-i-1)))));
			}
			Console.WriteLine("R"+r+"C"+value);
		}
		else
			Console.WriteLine("R"+r+"C"+(((int)c[0])-64));
	}
	private static string GetExcelColumnName(int columnNumber)
	{
		int dividend = columnNumber;
		string columnName = String.Empty;
		int modulo;

		while (dividend > 0)
		{
			modulo = (dividend - 1) % 26;
			columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
			dividend = (int)((dividend - modulo) / 26);
		} 

		return columnName;
	}
	public static void type2(string r, string c)
	{ // both input number
		if (int.Parse(c) > 26)
			Console.WriteLine(GetExcelColumnName(int.Parse(c))+r);
		else
			Console.WriteLine(((char)(int.Parse(c)+64))+r);
	}
	public static void Main()
	{
		long n = int.Parse(Console.ReadLine());
		string tokens;
		int counter = 0;
		string alphabet1 = "";
		string alphabet2 = "";
		string number1 = "";
		string number2 = "";
		
		int isNumber = -1;
		for (int i=0;i<n;i++){
			tokens = Console.ReadLine();
			isNumber = -1;
			alphabet1 = "";
			alphabet2 = "";
			number1 = "";
			number2 = "";
			counter = 0;
			while (counter < tokens.Length){
				if (Char.IsNumber(tokens[counter])){
					isNumber = 1;
					if (alphabet2.Equals(""))
						number1 += tokens[counter];
					else
						number2 += tokens[counter];
				}
				else{
					if (isNumber == -1)
						alphabet1 += tokens[counter];
					else
						alphabet2 += tokens[counter];
				}
				counter++;
			}
			if (number2.Equals("")) // type 1
			{
				type1(alphabet1, number1);
			}
			else // type 2
				type2(number1, number2);
		}
	}
}