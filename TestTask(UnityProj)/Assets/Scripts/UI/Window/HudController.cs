using Game;
using Time;
using UI.Elements;

namespace UI.Window
{
	public class HudController
	{
		private readonly GunsProvider _gunsProvider;
		private readonly MainTimeScaleManager _mainTimeScaleManager;

		public HudController(GunsProvider gunsProvider, MainTimeScaleManager mainTimeScaleManager)
		{
			_gunsProvider = gunsProvider;
			_mainTimeScaleManager = mainTimeScaleManager;
		}

		public void Open(HudView hudView)
		{
			InitMainTimeView(hudView.MainTimeScaleView);
			InitGunView(hudView.LeftGunPanelView, _gunsProvider.LeftGun);
			InitGunView(hudView.RightGunPanelView, _gunsProvider.RightGun);
			
			hudView.Show();
		}

		private void InitGunView(GunPanelView gunView, Gun gun)
		{
			gunView.Init(gun.TimeScaleRange, gun.TimeScale, gun.StartBullet);
			
			gun.ChangeBulletEvent += gunView.SelectBullet;
			gunView.ChangeBulletEvent += gun.ChangeBullet;
			
			gunView.UpdateTimeScaleValueEvent += gun.UpdateTimeScale;
		}

		private void InitMainTimeView(ITimeScaleView timeScaleView)
		{
			timeScaleView.Init(_mainTimeScaleManager.TimeRange, _mainTimeScaleManager.TimeScale);
			timeScaleView.ChangeInputEvent += _mainTimeScaleManager.ChangeTimeScale;
		}
	}
}