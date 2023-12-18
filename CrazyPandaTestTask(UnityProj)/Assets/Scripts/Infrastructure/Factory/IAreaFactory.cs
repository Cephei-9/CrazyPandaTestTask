using Chrono;

namespace CrazyPandaTestTask.Factory
{
	public interface IAreaFactory
	{
		IChronoArea CreateArea(AreasType type, InstantiateData instantiateData);
	}
}