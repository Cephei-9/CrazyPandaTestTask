using CrazyPandaTestTask.Factory;
using CrazyPandaTestTask.Input;
using CrazyPandaTestTask.Time;
using Infrostructure;

namespace CrazyPandaTestTask.Game
{
	public class GunsProvider
	{
		public Gun LeftGun { get; }
		public Gun RightGun { get; }

		public GunsProvider(LevelContext levelContext, IStaticData staticData, ITimeProvider mainTimeProvider, IInput input, IBulletFactory bulletFactory)
		{
			LeftGun = levelContext.LeftGun;
			RightGun = levelContext.RightGun;
			
			RightGun.Init(staticData.GunData, mainTimeProvider, input.RightGunInput, bulletFactory);
			LeftGun.Init(staticData.GunData, mainTimeProvider, input.LeftGunInput, bulletFactory);
		}
	}
}