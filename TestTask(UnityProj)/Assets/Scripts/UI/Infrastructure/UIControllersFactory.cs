using Zenject;

namespace UI.Infrastructure
{
	// Implementation of a controller factory that uses DI for bindings and access to controllers
	
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