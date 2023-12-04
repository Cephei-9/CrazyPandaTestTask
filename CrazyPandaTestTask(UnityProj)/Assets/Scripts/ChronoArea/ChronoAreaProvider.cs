using System.Collections.Generic;
using System.Linq;

namespace CrazyPandaTestTask
{
	public class ChronoAreaProvider
	{
		public float TimeWrapValue;
		public AreaBlendMode BlendMode;

		public ChronoAreaProvider(AreaBlendMode blendMode)
		{
			BlendMode = blendMode;
		}

		// In general, it would be optimized just to ChronoObject would add to the end of the poviders list Multiply
		// and to the beginning of Average, and in this method just one pass through the list and first work with Average
		// and then with Multiply
		public static float BlendAreasTimeWrap(IEnumerable<ChronoAreaProvider> providers)
		{
			if (providers.Count() == 0)
				return 1;

			float result = CalculateAverage(providers);

			foreach (ChronoAreaProvider provider in providers)
			{
				if (provider.BlendMode == AreaBlendMode.Multiply) 
					result *= provider.TimeWrapValue;
			}

			return result;
		}

		private static float CalculateAverage(IEnumerable<ChronoAreaProvider> providers)
		{
			float result = 0;
			int averageProvidersCount = 0;

			foreach (ChronoAreaProvider provider in providers)
			{
				if (provider.BlendMode != AreaBlendMode.Average)
					continue;

				result += provider.TimeWrapValue;
				averageProvidersCount++;
			}
			
			;
			return averageProvidersCount > 0 ? result / averageProvidersCount : 1;
		}
	}
}