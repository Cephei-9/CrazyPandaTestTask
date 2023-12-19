using System;
using CrazyPandaTestTask.Bullet;
using CrazyPandaTestTask.UI;
using UnityEngine;
using UnityEngine.Serialization;
using Range = CrazyPandaTestTask.Tools.Range;

namespace UI
{
	public class GunPanelView : MonoBehaviour
	{
		[SerializeField] 
		private TimeScaleView TimeScaleView;
		[SerializeField]
		private BulletSelectorView BulletSelectorView;

		public event Action<float> UpdateTimeScaleValueEvent;

		public void Init(Range timeRange, float startTimeValue, BulletType startBulletType)
		{
			TimeScaleView.Init(timeRange, startTimeValue);
			TimeScaleView.ChangeInputEvent += UpdateTimeScaleValue;
			
			BulletSelectorView.ShowBullet(startBulletType);
		}

		public void ShowBullet(BulletType bulletType)
		{
			BulletSelectorView.ShowBullet(bulletType);
		}

		private void UpdateTimeScaleValue(float newValue)
		{
			UpdateTimeScaleValueEvent?.Invoke(newValue);
		}
	}
}