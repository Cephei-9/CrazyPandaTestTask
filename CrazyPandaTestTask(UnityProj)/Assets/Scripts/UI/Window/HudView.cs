using UI.Elements;
using UnityEngine;

namespace UI.Window
{
	public class HudView : MonoBehaviour
	{
		[SerializeField]
		private TimeScaleView TimeScaleView;
		[SerializeField]
		private GunPanelView RightGunPanel, LeftGunPanel;
		
		public TimeScaleView MainTimeScaleView => TimeScaleView;
		public GunPanelView RightGunPanelView => RightGunPanel;
		public GunPanelView LeftGunPanelView => LeftGunPanel;
	}
}