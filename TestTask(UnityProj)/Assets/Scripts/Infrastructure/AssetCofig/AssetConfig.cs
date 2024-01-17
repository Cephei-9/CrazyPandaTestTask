using Bullet;
using Bullet.ConcreteBullets;
using Chrono;
using UI.Window;
using UnityEngine;

namespace Infrastructure.AssetCofig
{
	[CreateAssetMenu(fileName = "AssetConfig", menuName = "GameData/AssetConfig")]
	public class AssetConfig : ScriptableObject, IAssetConfig
	{
		public ChronoArea ChronoAreaPrefab;
		public GameObject UIRootPrefab;
		public HudView HudViewPrefab;
		
		public SimpleBullet SimpleBulletPrefab;
		public GhostBullet GhostBulletPrefab;
		public InvertBullet InvertBulletPrefab;
		public ChaoticBullet ChaoticBulletPrefab;

		public ChronoArea ChronoArea => ChronoAreaPrefab;
		public GameObject UIRoot => UIRootPrefab;
		public HudView HudView => HudViewPrefab;
		public SimpleBullet SimpleBullet => SimpleBulletPrefab;
		public GhostBullet GhostBullet => GhostBulletPrefab;
		public InvertBullet InvertBullet => InvertBulletPrefab;
		public ChaoticBullet ChaoticBullet => ChaoticBulletPrefab;
	}
}