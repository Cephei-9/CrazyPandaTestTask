namespace UI.Infrastructure
{
	public interface IUIControllersFactory
	{
		TController GetController<TController>();
	}
}