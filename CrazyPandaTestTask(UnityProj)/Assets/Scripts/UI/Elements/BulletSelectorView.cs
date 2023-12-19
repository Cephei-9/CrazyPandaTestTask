using System;
using Bullet;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Elements
{
	public class BulletSelectorView : MonoBehaviour
	{
		[SerializeField]
		private Color SimpleBullet;
		[SerializeField]
		private Color GhostBullet;
		[SerializeField]
		private Color InvertBullet;
		[SerializeField]
		private Color ChaoticBullet;

		[SerializeField]
		private Image Image;

		private BulletType _currentBullet;

		public void ShowBullet(BulletType type)
		{
			Color nextColor = type switch
			{
				BulletType.Simple => SimpleBullet,
				BulletType.Ghost => GhostBullet,
				BulletType.Invert => InvertBullet,
				BulletType.Chaotic => ChaoticBullet,
				_ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
			};

			ShowSprite(nextColor);
		}

		private void ShowSprite(Color color)
		{
			Image.color = color;
		}
	}
}