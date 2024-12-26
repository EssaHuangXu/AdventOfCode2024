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
				var split = line.Split( "   " );
				if( split.Length >= 2 )
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

			//Day 2
			//int[][] reports =
			//[
			//	[7, 6, 4, 2, 1],
			//	[1, 2, 7, 8, 9],
			//	[9, 7, 6, 2, 1],
			//	[1, 3, 2, 4, 5],
			//	[8, 6, 4, 4, 1],
			//	[1, 3, 6, 7, 9]
			//];
			string filePath = "RedNosedReportsInput.txt"; // Path to your input file
			int[][] reports = ConvertToIntReportsArray( filePath );
			result = RedNosedReports.SafeReports( reports );
			Console.WriteLine( "AdventOfCode2024 Day 2 RedNosedReports Result is:" + result.ToString() );

			// TODO: not correctly
			//result = RedNosedReports.SingleBadLevelSafeReports( reports );
			//Console.WriteLine( "AdventOfCode2024 Day 2 RedNosedReports Single Level Tolerate Result is:" + result.ToString() );

			//Day 3
			var input = File.ReadAllText( "MullItOverInput.txt" );
			var mullItOverResult = MullItOver.Multiply( input );
			Console.WriteLine( "AdventOfCode2024 Day 3 MullItOver Result is:" + mullItOverResult.ToString() );
			mullItOverResult = MullItOver.Multiply2( input );
			Console.WriteLine( "AdventOfCode2024 Day 3 MullItOver Part Two Result is:" + mullItOverResult.ToString() );
		}


		public static int[][] ConvertToIntReportsArray( string filePath )
		{
			// Read all lines from the file
			string[] lines = File.ReadAllLines( filePath );

			// Convert each line to an array of integers
			int[][] jaggedArray = lines
				.Select( line => line.Split( new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries )
									.Select( int.Parse )
									.ToArray() )
				.ToArray();

			return jaggedArray;
		}
	}
}
