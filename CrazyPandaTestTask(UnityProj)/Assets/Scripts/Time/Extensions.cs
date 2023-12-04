using System;
using System.Collections.Generic;
using DefaultNamespace.Runtime;
using UnityEngine;

namespace CrazyPandaTestTask
{
	public static class Extensions
	{
		public static void SmartRemove<T>(this List<T> list, T element)
		{
			int indexOfElement = list.IndexOf(element);
			
			if (indexOfElement != -1)
				list.SmartRemove(indexOfElement);
		}
		
		public static void SmartRemove<T>(this List<T> list, int index)
		{
			list[index] = list[^1];
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

		public static void Update(this IEnumerable<IUpdatable> updatable)
		{
			foreach (IUpdatable localUpdatable in updatable)
			{
				localUpdatable.UpdateWork();
			}
		}
	}
}