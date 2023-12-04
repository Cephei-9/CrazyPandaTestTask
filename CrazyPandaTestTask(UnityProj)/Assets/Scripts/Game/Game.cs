using System;
using CrazyPandaTestTask.Factory;
using CrazyPandaTestTask.Input;
using CrazyPandaTestTask.Time;
using CrazyPandaTestTask.UI;
using UnityEngine;
using Range = CrazyPandaTestTask.Tools.Range;

namespace CrazyPandaTestTask.Game
{
	public class Game : MonoBehaviour
	{
		private const float START_GAME_TIME_SCALE = 1;
		
		[SerializeField]
		private BulletConfigs BulletConfigs;
		[SerializeField]
		private AreaSwitcher AreaSwitcher;
		[SerializeField]
		private TimeScaleSlider MainTimeScaleSlider;
		[SerializeField]
		private Range MainTimeScaleRange = new(0, 2);

		[Space]
		[SerializeField]
		private GunConfig LeftGunConfig;
		[SerializeField]
		private GunConfig RightGunConfig;
		
		private StandAloneInput _input;

		private void Start()
		{
			TestFactory factory = new(BulletConfigs);
			TimeProviderDecorator mainProvider = new(ITimeProvider.Default);
			
			InitInput();
			InitAreaSwitcher();
			InitGuns(mainProvider, factory);
			InitMainTime(mainProvider);
		}

		private void InitMainTime(IWritableTimeProvider mainProvider)
		{
			MainTimeScaleSlider.Init(MainTimeScaleRange, START_GAME_TIME_SCALE);
			MainTimeScaleSlider.ChangeInputEvent += mainProvider.ChangeTimeScale;
		}

		private void InitAreaSwitcher()
		{
			AreaSwitcher.Init(_input.AreaChangeInput);
		}

		private void InitGuns(ITimeProvider mainProvider, IBulletFactory factory)
		{
			LeftGunConfig.Init(mainProvider, _input.LeftGunInput, factory);
			RightGunConfig.Init(mainProvider, _input.RightGunInput, factory);
		}

		private void InitInput()
		{
			_input = new StandAloneInput();
		}

		private void Update()
		{
			_input.UpdateWork();
		}

		[Serializable]
		private class GunConfig
		{
			public Gun.Gun.Data GunData;
			public TimeScaleSlider TimeScaleSlider;
			public BulletSelectorView BulletSelectorView;
			public Gun.Gun Gun;

			public void Init(ITimeProvider originProvider, GunInput input, IBulletFactory factory)
			{
				Gun.Init(GunData, originProvider, input, factory, BulletSelectorView, TimeScaleSlider);
			}
		}
	}
}