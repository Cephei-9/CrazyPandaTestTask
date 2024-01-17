using Bullet;
using Bullet.ConcreteBullets;
using Chrono;
using UI.Window;
using UnityEngine;

namespace Infrastructure.AssetCofig
{
	public interface IAssetConfig
	{
		ChronoArea ChronoArea { get; }
		GameObject UIRoot { get; }
		HudView HudView { get; }
		SimpleBullet SimpleBullet { get; }
		GhostBullet GhostBullet { get; }
		InvertBullet InvertBullet { get; }
		ChaoticBullet ChaoticBullet { get; }
	}
}