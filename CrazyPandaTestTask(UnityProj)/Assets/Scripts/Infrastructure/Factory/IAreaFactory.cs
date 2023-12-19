using Chrono;

namespace Infrastructure.Factory
{
	public interface IAreaFactory
	{
		IChronoArea CreateArea(AreasType type, InstantiateData instantiateData);
	}
}