namespace CrazyPandaTestTask
{
	public interface IChronoObject
	{
		void EnterArea(ChronoAreaProvider areaProvider);

		void ExitArea(ChronoAreaProvider areaProvider);
	}
}