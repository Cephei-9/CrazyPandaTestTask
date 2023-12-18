using Chrono;
using CrazyPandaTestTask.Bullet;
using CrazyPandaTestTask.Game;
using CrazyPandaTestTask.Tools;
using UnityEngine.Serialization;

namespace Infrostructure
{
	public interface IStaticData
	{
		AreaSwitcher.Data AreaSwitcherData { get; }

		Gun.Data GunData { get; }

		Range MainTimeScaleRange { get; }

		BulletData SimpleBulletData { get; }
		InvertBullet.Data InvertBulletData { get; }
		BulletData GhostBulletData { get; }
		ChaoticBullet.Data ChaoticBulletData { get; }

		ChronoArea.Data GetChronoAreaData(AreasType type);
	}
}