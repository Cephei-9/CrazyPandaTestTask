using System.Collections.Generic;

namespace Chrono
{
	public class ChronoAreaProvider
	{
		public float TimeWrapValue;
		public AreaBlendMode BlendMode;

		public ChronoAreaProvider(AreaBlendMode blendMode)
		{
			BlendMode = blendMode;
		}
		
		public static float BlendAreasTimeWrap(IEnumerable<ChronoAreaProvider> providers)
		{
			float averageResult = 0;
			float multiplyResult = 1;
			int averageProvidersCount = 0;
			
			foreach (ChronoAreaProvider provider in providers)
			{
				if (provider.BlendMode == AreaBlendMode.Average)
				{
					averageResult += provider.TimeWrapValue;
					averageProvidersCount++;
				}
				else
					multiplyResult *= provider.TimeWrapValue;
			}

			averageResult = averageProvidersCount == 0 ? 1 : averageResult / averageProvidersCount;
			return averageResult * multiplyResult;
		}
	}
}