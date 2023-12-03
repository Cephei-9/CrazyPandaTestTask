using System;
using Random = UnityEngine.Random;

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
}