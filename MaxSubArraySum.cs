//Find the Contiguous subarray within an array(containing at least one number) 
//which has the largest sum.

using System;
using System.Collections;

namespace MaxSubArraySum
{
	public class Finder
	{
		public static bool IsAllNegative(int[] a)
		{
			foreach (int e in a) {  //O(n)
				if (e > 0)
					return false; 
			}
			return true;
		}

		//solution1
		public static int FindLargestSum(int[] a) //time: O(n)  space: O(1)
		{
			if (!IsAllNegative (a)) {
				int MaxSoFar = 0, MaxHere = 0;
				foreach (int e in a) {  //O(n)
					MaxHere = MaxHere + e;
					MaxHere = Max (MaxHere, 0);	
					if(MaxHere >0)
						MaxSoFar = Max (MaxHere, MaxSoFar); 
				}
				return MaxSoFar;
			} else {
				int max = a [0];
				for (int i=0;i<a.Length;i++) { //O(n)
					max = Max (max, a [i]);
				}
				return max;
			}
		}

		private static int Max(int first, int second)
		{
			return (first > second) ? first : second;
		}

		//solution2
		public static int FindLargestSumSimple(int[] a)//time: O(n) space: O(1)
		{
			int MaxSoFar = a [0];
			int MaxHere = a [0];
			for (int i = 1; i < a.Length; i++) {
				MaxHere = Max (a [i], MaxHere + a [i]);
				MaxSoFar = Max (MaxHere, MaxSoFar);
			}
			return MaxSoFar;
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			int[] test = new int[6]{ 2, -4, -4, 5, 9, 3 };
			Console.WriteLine (Finder.FindLargestSum (test));
			Console.WriteLine (Finder.FindLargestSumSimple (test));
		}
	}
}