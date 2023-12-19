using Infrastructure.Factory;
using Infrastructure.StaticData;
using Input;
using Time.Infrastructure;

namespace Game
{
	public class GunsProvider
	{
		public Gun LeftGun { get; }
		public Gun RightGun { get; }

		public GunsProvider(LevelContext levelContext, IStaticData staticData, ITimeProvider mainTimeProvider, IInput input, IBulletFactory bulletFactory)
		{
			LeftGun = levelContext.GetLeftGun;
			RightGun = levelContext.GetRightGun;
			
			RightGun.Init(staticData.GunData, mainTimeProvider, input.RightGunInput, bulletFactory);
			LeftGun.Init(staticData.GunData, mainTimeProvider, input.LeftGunInput, bulletFactory);
		}
	}
}