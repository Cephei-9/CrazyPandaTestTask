using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
	public class BulletSelectorView : MonoBehaviour, IBulletSelectorView
	{
		[SerializeField]
		private Sprite SimpleBullet;
		[SerializeField]
		private Sprite GhostBullet;
		[SerializeField]
		private Sprite InvertBullet;
		[SerializeField]
		private Sprite ChaoticBullet;

		[SerializeField]
		private Image Image;

		private BulletType _currentBullet;

		public void ShowBullet(BulletType type)
		{
			Sprite nextSprite = type switch
			{
				BulletType.Simple => SimpleBullet,
				BulletType.Ghost => GhostBullet,
				BulletType.Invert => InvertBullet,
				BulletType.Chaotic => ChaoticBullet,
				_ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
			};

			ShowSprite(nextSprite);
		}

		private void ShowSprite(Sprite sprite)
		{
			Image.sprite = sprite;
		}
	}
}