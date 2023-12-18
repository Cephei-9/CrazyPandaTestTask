using Chrono;
using UnityEngine;

namespace CrazyPandaTestTask.Factory
{
	[CreateAssetMenu(fileName = "AssetConfig", menuName = "GameData/AssetConfig")]
	public class AssetConfig : ScriptableObject, IAssetConfig
	{
		public ChronoArea ChronoArea;

		public ChronoArea ChronoAreaPrefab => ChronoArea;
	}
}