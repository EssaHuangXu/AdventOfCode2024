using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
	internal class RedNosedReports
	{
		public static bool IsValidArray( int[] array )
		{
			if( array.Length < 2 )
			{
				return false;
			}

			bool isIncreasing = true;
			bool isDecreasing = true;

			for( int i = 1; i < array.Length; i++ )
			{
				int diff = array[i] - array[i - 1];

				if( diff <= 0 || diff > 3 )
				{
					isIncreasing = false;
				}

				if( diff >= 0 || diff < -3 )
				{
					isDecreasing = false;
				}
			}

			return isIncreasing || isDecreasing;
		}

		public static int SafeReports( int[][] reports )
		{
			int count = 0;

			foreach( var array in reports )
			{
				if( IsValidArray( array ) )
				{
					count++;
				}
			}

			return count;
		}
	
		public static bool DiffValid(ref int[] array, int i, int j, out int signal )
		{
			var diff = array[j] - array[i];
			var absDiff = Math.Abs( diff );
			if (absDiff == 0)
			{
				signal = 0;
				return false;
			}

			signal = diff / Math.Abs( diff );
			return absDiff > 0 && absDiff <= 3;
		}

		public static bool IsSingleBadLevelValid( int[] array )
		{
			if( array.Length < 2 )
			{
				return false;
			}

			if( DiffValid( ref array, 0, 1, out var signal ) == false )
			{
				return false;
			}

			var dp = 0;
			for( int i = 2; i < array.Length; i++ )
			{
				var compareLast = DiffValid( ref array, i - 1, i, out var signalLast );
				if (compareLast == true && signalLast * signal > 0 )
				{
					continue;
				}
				else
				{
					var compareLastLast = DiffValid(ref array, i - 2, i, out var signalLastLast);
					if(compareLastLast == true && signal * signalLastLast > 0)
					{
						dp++;
						continue;
					}
					else
					{
						return false;
					}
				}
			}

			return dp <= 1;
		}

		public static int SingleBadLevelSafeReports( int[][] reports )
		{
			int count = 0;
			foreach( var array in reports )
			{
				if( IsSingleBadLevelValid( array ) )
				{
					count++;
				}
			}

			return count;
		}
	}
}
