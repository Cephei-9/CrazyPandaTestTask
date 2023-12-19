namespace Chrono
{
	public interface IChronoArea
	{
		public static IChronoArea Empty => new EmptyChronoArea();

		void SetActiveStatus(bool status);
	}

	public class EmptyChronoArea : IChronoArea
	{
		public void SetActiveStatus(bool status) { }
	}
}