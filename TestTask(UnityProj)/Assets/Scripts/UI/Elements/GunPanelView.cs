using System;
using Bullet;
using UnityEngine;
using Range = Tools.Range;

namespace UI.Elements
{
	public class GunPanelView : MonoBehaviour
	{
		[SerializeField] 
		private TimeScaleView TimeScaleView;
		[SerializeField]
		private BulletSelectorView BulletSelectorView;

		public event Action<float> UpdateTimeScaleValueEvent;
		public event Action<BulletType> ChangeBulletEvent;

		public void Init(Range timeRange, float startTimeValue, BulletType startBulletType)
		{
			TimeScaleView.Init(timeRange, startTimeValue);
			TimeScaleView.ChangeInputEvent += f => UpdateTimeScaleValueEvent?.Invoke(f);
			
			BulletSelectorView.Init(startBulletType);
			BulletSelectorView.ChangeBulletEvent += b => ChangeBulletEvent?.Invoke(b);
		}

		public void SelectBullet(BulletType bulletType)
		{
			BulletSelectorView.SelectBullet(bulletType);
		}
	}
}