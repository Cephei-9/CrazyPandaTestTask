using CrazyPandaTestTask.UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI
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