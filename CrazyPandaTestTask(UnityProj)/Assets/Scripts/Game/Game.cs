using System;
using CrazyPandaTestTask.Factory;
using CrazyPandaTestTask.Input;
using CrazyPandaTestTask.Time;
using CrazyPandaTestTask.UI;
using Installers;
using UnityEngine;
using Zenject;

namespace CrazyPandaTestTask.Game
{
	public class Game : MonoBehaviour
	{
		[SerializeField]
		private GunConfig LeftGunConfig;
		[SerializeField]
		private GunConfig RightGunConfig;

		[Inject]
		private void Construct(ITimeProvider mainProvider, IInput input, IBulletFactory bulletFactory, TestZenjectPrefab testZenjectPrefab)
		{
			InitGuns(mainProvider, bulletFactory, input);
			// check prefab

			Debug.Log(mainProvider.GetHashCode());
		}

		private void InitGuns(ITimeProvider mainProvider, IBulletFactory factory, IInput input)
		{
			LeftGunConfig.Init(mainProvider, input.LeftGunInput, factory);
			RightGunConfig.Init(mainProvider, input.RightGunInput, factory);
		}

		[Serializable]
		private class GunConfig
		{
			public Gun.Data GunData;
			public TimeScaleSlider TimeScaleSlider;
			public BulletSelectorView BulletSelectorView;
			public Gun Gun;

			public void Init(ITimeProvider originProvider, GunInput input, IBulletFactory factory)
			{
				Gun.Init(GunData, originProvider, input, factory, BulletSelectorView, TimeScaleSlider);
			}
		}
	}
}