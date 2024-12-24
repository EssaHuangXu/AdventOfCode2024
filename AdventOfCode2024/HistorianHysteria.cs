using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
	internal class HistorianHysteria
	{
		public static int DistanceWithInTowList( int[] left, int[] right )
		{
			var count = left.Length >= right.Length ? right.Length : left.Length;
			Array.Sort( left );
			Array.Sort( right );
			int distance = 0;
			for( int i = 0; i < count; i++ )
			{
				distance += Math.Abs( left[i] - right[i] );
			}

			return distance;
		}

		public static int SimilarityWithInTowList( int[] left, int[] right )
		{
			var dic = right.GroupBy( x => x ).ToDictionary( g => g.Key, g => g.Count() );
			var result = 0;
			for( int i = 0; i < left.Length; i++ )
			{
				result += left[i] * ( dic.TryGetValue( left[i], out int value ) ? value : 0 );
			}
			return result;
		}
	}
}
