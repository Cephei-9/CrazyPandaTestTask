using CrazyPandaTestTask.Factory;
using CrazyPandaTestTask.Time;
using CrazyPandaTestTask.Tools;
using CrazyPandaTestTask.UI;
using UnityEngine;
using Zenject;

namespace Installers
{
	public class LevelInstaller : MonoInstaller<LevelInstaller>
	{
		public TestZenjectPrefab TestPrefab;
		public TimeScaleSlider TimeScaleSlider;
		
		public override void InstallBindings()
		{
			BindTime();
			BindTimeController();
			BindTestPrefab();
			BindAreasFactory();
		}

		private void BindAreasFactory()
		{
			Container.BindInterfacesTo<Factory>().AsSingle();
		}

		private void BindTimeController()
		{
			Container.BindInterfacesAndSelfTo<TimeScaleSlider>().FromInstance(TimeScaleSlider);
			Container.Bind<MainTimeController>().AsSingle().WithArguments(new Range(0, 2)).NonLazy();
		}

		private void BindTime()
		{
			Container.Bind(typeof(ITimeProvider), typeof(IWritableTimeProvider)).To<TimeProviderDecorator>()
				.FromInstance(IWritableTimeProvider.Main).AsSingle();
		}

		private void BindTestPrefab()
		{
			TestZenjectPrefab testZenject =
				Container.InstantiatePrefabForComponent<TestZenjectPrefab>(TestPrefab, Vector3.zero,
					Quaternion.identity, null);
			
			Container.Bind<TestZenjectPrefab>().FromInstance(testZenject).AsSingle();
		}
	}
}