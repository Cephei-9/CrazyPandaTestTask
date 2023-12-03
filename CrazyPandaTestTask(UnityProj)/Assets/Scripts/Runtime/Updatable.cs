namespace DefaultNamespace.Runtime
{
	public interface IUpdatable
	{
		void UpdateWork();
	}

	public interface IFixedUpdatable : IUpdatable
	{
		
	}
}