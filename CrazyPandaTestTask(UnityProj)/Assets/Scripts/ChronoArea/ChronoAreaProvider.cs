using System.Collections.Generic;
using System.Linq;

namespace CrazyPandaTestTask
{
	public class ChronoAreaProvider
	{
		public float TimeWrapValue;
		public ChronoArea.AreaBlendMode BlendMode;

		public ChronoAreaProvider(ChronoArea.AreaBlendMode blendMode)
		{
			BlendMode = blendMode;
		}

		// In general, it would be optimized just to ChronoObject would add to the end of the poviders list Multiply
		// and to the beginning of Average, and in this method just one pass through the list and first work with Average
		// and then with Multiply
		public static float BlendAreasTimeWrap(IEnumerable<ChronoAreaProvider> providers)
		{
			float result = 0;
			int averageProvidersCount = 0;

			foreach (ChronoAreaProvider provider in providers)
			{
				if (provider.BlendMode != ChronoArea.AreaBlendMode.Average) 
					continue;

				result += provider.TimeWrapValue;
				averageProvidersCount++;
			}

			result /= averageProvidersCount;
			
			foreach (ChronoAreaProvider provider in providers)
			{
				if (provider.BlendMode == ChronoArea.AreaBlendMode.Multiply) 
					result *= provider.TimeWrapValue;
			}

			return result;
		}
	}
}