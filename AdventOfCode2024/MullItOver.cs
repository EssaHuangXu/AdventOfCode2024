using System;
using System.Text.RegularExpressions;

namespace AdventOfCode2024
{
	internal class MullItOver
	{
		public static int Multiply(string input)
		{
			var result = 0;
			var matches = Regex.Matches( input, @"mul\((\d+),(\d+)\)" );
			foreach ( Match match in matches )
			{
				int firstNumber = int.Parse( match.Groups[1].Value );
				int secondNumber = int.Parse( match.Groups[2].Value );
				result = result + firstNumber * secondNumber;
			}
			return result;
		}

		public static int Multiply2( string input )
		{
			var result = 0;

			var queue1 = new Queue<Match>( Regex.Matches( input, @"do\(\)" ) );
			var queue2 = new Queue<Match>( Regex.Matches( input, @"don't\(\)" ) );

			if( queue2.Count == 0 )
			{
				return Multiply( input );
			}
			else
			{
				var doIndex = -1;
				var dontIndex = queue2.Peek().Index;
				var matches = Regex.Matches( input, @"mul\((\d+),(\d+)\)" );
				foreach( Match match in matches )
				{
					var currentIndex = match.Index;
					if( currentIndex > doIndex && currentIndex < dontIndex )
					{
						int firstNumber = int.Parse( match.Groups[1].Value );
						int secondNumber = int.Parse( match.Groups[2].Value );
						result = result + firstNumber * secondNumber;
					}
					else
					{
						if( currentIndex > doIndex )
						{
							while( queue1.Count > 0 && currentIndex > queue1.Peek().Index )
							{
								queue1.Dequeue();
							}

							doIndex = queue1.Count > 0 ? queue1.Peek().Index : input.Length;
						}

						if( currentIndex > dontIndex )
						{
							while( queue2.Count > 0 && currentIndex > queue2.Peek().Index )
							{
								queue2.Dequeue();
							}

							dontIndex = queue2.Count > 0 ? queue2.Peek().Index : input.Length;
						}
					}
				}
			}
			
			return result;
		}
	}
}
