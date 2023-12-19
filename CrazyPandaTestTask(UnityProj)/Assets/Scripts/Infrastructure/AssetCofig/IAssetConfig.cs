using Chrono;
using CrazyPandaTestTask.Bullet;
using UI;
using UnityEngine;

namespace CrazyPandaTestTask.Factory
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