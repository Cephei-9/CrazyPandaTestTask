using Bullet;
using Bullet.ConcreteBullets;
using Chrono;
using Game;
using Tools;
using UnityEngine;

namespace Infrastructure.StaticData
{
	[CreateAssetMenu(fileName = "DataConfig", menuName = "GameData/DataConfig")]
	public class DataConfig : ScriptableObject, IStaticData
	{
		[SerializeField]
		private ChronoArea.Data SlowingDownStatically;
		[SerializeField]
		private ChronoArea.Data SlowingDownDynamically;
		[SerializeField]
		private ChronoArea.Data AcceleratingDynamically;
		[Space]
		[SerializeField]
		private AreaSwitcher.Data AreaSwitcher;
		[SerializeField]
		private Gun.Data Gun;
		[SerializeField]
		private Range MainTimeScale;
		[Space]
		[SerializeField]
		private BulletData SimpleBullet;
		[SerializeField]
		private InvertBullet.Data InvertBullet;
		[SerializeField]
		private BulletData GhostBullet;
		[SerializeField]
		private ChaoticBullet.Data ChaoticBullet;
		public AreaSwitcher.Data AreaSwitcherData => AreaSwitcher;
		public Gun.Data GunData => Gun;
		public Range MainTimeScaleRange => MainTimeScale;
		
		public BulletData SimpleBulletData => SimpleBullet;
		public InvertBullet.Data InvertBulletData => InvertBullet;
		public BulletData GhostBulletData => GhostBullet;
		public ChaoticBullet.Data ChaoticBulletData => ChaoticBullet;

		public ChronoArea.Data GetChronoAreaData(AreasType type)
		{
			return type switch
			{
				AreasType.SlowingDownStatically => SlowingDownStatically,
				AreasType.SlowingDownDynamically => SlowingDownDynamically,
				AreasType.AcceleratingDynamically => AcceleratingDynamically,
				_ => null
			};
		}
	}
}