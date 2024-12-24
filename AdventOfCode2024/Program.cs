using System.Diagnostics;

namespace AdventOfCode2024
{
	internal class Program
	{
		static void Main( string[] args )
		{
			// Day 1
			List<int> left = [];
			List<int> right = [];
			using FileStream fileStream = new( "HistorianHysteriaInput.txt", FileMode.Open );
			using StreamReader reader = new( fileStream );
			var line = reader.ReadLine();
			while( line != null )
			{
				var split = line.Split("   ");
				if ( split.Length >= 2 )
				{
					left.Add( int.Parse( split[0] ) );
					right.Add( int.Parse( split[1] ) );
				}
				line = reader.ReadLine();
			}
			var result = HistorianHysteria.DistanceWithInTowList( [.. left], [.. right] );
			Console.WriteLine( "AdventOfCode2024 Day 1 HistorianHysteria Result is :" + result.ToString() );
			result = HistorianHysteria.SimilarityWithInTowList( [.. left], [.. right] );
			Console.WriteLine( "AdventOfCode2024 Day 1 HistorianHysteria Similarity Result is :" + result.ToString() );
		}
	}
}
