namespace UI.Infrastructure
{
	// Controllers object factory
	public interface IUIControllersFactory
	{
		TController GetController<TController>();
	}
}