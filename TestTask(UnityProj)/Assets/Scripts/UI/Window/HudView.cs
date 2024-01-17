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
		
		public ITimeScaleView MainTimeScaleView => TimeScaleView;
		public GunPanelView RightGunPanelView => RightGunPanel;
		public GunPanelView LeftGunPanelView => LeftGunPanel;

		public void Show()
		{
			gameObject.SetActive(true);
		}

		public void Hide()
		{
			gameObject.SetActive(false);
		}
	}
}