using UI.Window;

namespace UI.Infrastructure
{
	public interface IUIFactory
	{
		HudView CreateHud();
	}
}