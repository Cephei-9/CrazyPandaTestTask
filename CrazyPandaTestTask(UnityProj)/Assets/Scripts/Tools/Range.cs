using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CrazyPandaTestTask.Tools
{
	[Serializable]
	public class Range
	{
		public float Min = 0;
		public float Max = 0;

		public Range(float min, float max)
		{
			Min = min;
			Max = max;
		}

		public float GetRandom()
		{
			return Random.Range(Min, Max);
		}

		public float Lerp(float t)
		{
			return Mathf.Lerp(Min, Max, t);
		}

		public float Clamp(float value)
		{
			return Mathf.Clamp(value, Min, Max);
		}
	}
}