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

		[SerializeField]
		private GunConfig LeftGunConfig;
		[SerializeField]
		private GunConfig RightGunConfig;
		
		private StandAloneInput _input;

		private void Start()
		{
			_input = new StandAloneInput();
			TestFactory factory = new TestFactory(BulletConfigs);

			TimeProviderDecorator mainProvider = new TimeProviderDecorator(ITimeProvider.Default);

			LeftGunConfig.Init(mainProvider, _input.LeftGunInput, factory);
			RightGunConfig.Init(mainProvider, _input.RightGunInput, factory);
			
			AreaSwitcher.Init(_input.AreaChangeInput);
			
			MainTimeScaleSlider.Init(MainTimeScaleRange, START_GAME_TIME_SCALE);
			MainTimeScaleSlider.ChangeInputEvent += (t) => mainProvider.ChangeTimeScale(t);
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