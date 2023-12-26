using UI.Window;

namespace UI.Infrastructure
{
	// View objects factory
	public interface IUIFactory
	{
		HudView CreateHud();
	}
}