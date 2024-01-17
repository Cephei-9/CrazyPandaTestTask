using System;
using Bullet;
using Time.Infrastructure;
using UnityEngine;

namespace UI.Elements
{
	public class BulletSelectorView : MonoBehaviour
	{
		[SerializeField]
		private float SelectedScale = 1.3f;
		[SerializeField]
		private float HighlightedScale = 1.1f;
		[SerializeField]
		private float AnimationSpeed = 1;
		
		[Space]
		[SerializeField]
		private BulletProvider<Color> BulletColors;
		[SerializeField]
		private BulletButton BulletButtonPrefab;
		[SerializeField]
		private RectTransform LayoutRoot;

		public event Action<BulletType> ChangeBulletEvent;

		private BulletButton[] _buttons;
		private BulletButton _currentButton;

		public void Init(BulletType startBullet)
		{
			CreateButtons();
			SelectStartBulletButton(startBullet);
		}

		private void Update()
		{
			UpdateButtonsScale();
		}

		public void SelectBullet(BulletType bulletType)
		{
			_currentButton.IsSelected = false;
			_currentButton = _buttons[(int)bulletType];
			_currentButton.IsSelected = true;
		}

		private void CreateButtons()
		{
			int bulletTypeCount = (int)BulletType.Max;
			_buttons = new BulletButton[bulletTypeCount];

			for (int i = 0; i < bulletTypeCount; i++)
			{
				BulletType bulletType = (BulletType)i;
				BulletButton newButton = Instantiate(BulletButtonPrefab, LayoutRoot);
				
				newButton.Init(bulletType, BulletColors.GetBullet(bulletType));

				newButton.ClickEvent += OnButtonClick;
				_buttons[i] = newButton;
			}
		}

		private void SelectStartBulletButton(BulletType startBullet)
		{
			BulletButton startBulletButton = _buttons[(int)startBullet];
			_currentButton = startBulletButton;

			_currentButton.IsSelected = true;
			_currentButton.SetScale(SelectedScale);
		}

		private void OnButtonClick(BulletType bulletType, BulletButton button)
		{
			if (button == _currentButton)
				return;
			
			_currentButton.IsSelected = false;
			_currentButton = button;
			_currentButton.IsSelected = true;
			
			ChangeBulletEvent?.Invoke(bulletType);
		}

		private void UpdateButtonsScale()
		{
			foreach (BulletButton bulletButton in _buttons)
			{
				float targetScale = CalculateTargetScale(bulletButton);

				float delta = ITimeProvider.Unscaled.DeltaTime * AnimationSpeed;
				float nextScale = Mathf.Lerp(bulletButton.CurrentScale, targetScale, delta);

				bulletButton.SetScale(nextScale);
			}
		}

		private float CalculateTargetScale(BulletButton bulletButton)
		{
			float selectedScale = bulletButton.IsSelected ? SelectedScale : 1;
			float highlightedScale = bulletButton.IsHighlighted ? HighlightedScale : 1;
			
			return selectedScale * highlightedScale;
		}
	}
}