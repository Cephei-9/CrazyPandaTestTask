using Zenject;

namespace UI.Infrastructure
{
	public class UIControllersFactory : IUIControllersFactory
	{
		private readonly DiContainer _container;

		public UIControllersFactory(DiContainer container)
		{
			_container = container;
		}
		
		public TController GetController<TController>()
		{
			return _container.Resolve<TController>();
		}
	}
}