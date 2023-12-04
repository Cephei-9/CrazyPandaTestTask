using System;
using CrazyPandaTestTask.Factory;
using CrazyPandaTestTask.Input;
using CrazyPandaTestTask.Time;
using CrazyPandaTestTask.UI;
using UnityEngine;

namespace CrazyPandaTestTask.Game
{
	public class Game : MonoBehaviour
	{
		[SerializeField]
		private BulletConfigs BulletConfigs;
		[SerializeField]
		private AreaSwitcher AreaSwitcher;

		[SerializeField]
		private GunConfig LeftGunConfig;
		[SerializeField]
		private GunConfig RightGunConfig;
		
		private StandAloneInput _input;

		private void Start()
		{
			_input = new StandAloneInput();
			TestFactory factory = new TestFactory(BulletConfigs);

			ITimeProvider timeProvider = ITimeProvider.Default;
			LeftGunConfig.Init(timeProvider, _input.LeftGunInput, factory);
			RightGunConfig.Init(timeProvider, _input.RightGunInput, factory);
			
			AreaSwitcher.Init(_input.AreaChangeInput);
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