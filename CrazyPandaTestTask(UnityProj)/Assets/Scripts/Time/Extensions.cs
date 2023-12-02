using System;
using System.Collections.Generic;
using UnityEngine;

namespace CrazyPandaTestTask
{
	public static class Extensions
	{
		public static void SmartRemove<T>(this List<T> list, T element)
		{
			int indexOfElement = list.IndexOf(element);
			
			if (indexOfElement == -1)
				return;

			list[indexOfElement] = list[^1];
			list.RemoveAt(list.Count - 1);
		}

		public static bool IsEquals(this float firstValue, float secondValue)
		{
			return Math.Abs(firstValue - secondValue) < Mathf.Epsilon;
		}
		
		public static bool IsNotEquals(this float firstValue, float secondValue)
		{
			return Math.Abs(firstValue - secondValue) > Mathf.Epsilon;
		}
		
		public static bool IsMore(this float firstValue, float secondValue)
		{
			return firstValue - secondValue > Mathf.Epsilon;
		}
		
		public static bool IsLess(this float firstValue, float secondValue)
		{
			return firstValue - secondValue < Mathf.Epsilon;
		}
	}
}