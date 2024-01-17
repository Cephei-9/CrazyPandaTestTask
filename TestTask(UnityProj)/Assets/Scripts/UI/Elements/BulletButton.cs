using System;
using Bullet;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Elements
{
	public class BulletButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
	{
		private const float ScaleDrop = 0.01f;
		
		[SerializeField]
		private Image Image;
		[SerializeField]
		private LayoutElement LayoutElement;
		
		public event Action<BulletType, BulletButton> ClickEvent;

		public bool IsSelected { get; set; }
		public bool IsHighlighted { get; private set; }
		public float CurrentScale { get; private set; }
		public BulletType BulletType { get; private set; }

		public void Init(BulletType type, Color color)
		{
			Image.color = color;
			BulletType = type;

			CurrentScale = 1;
		}

		public void SetScale(float newScale)
		{
			CurrentScale = newScale;
			LayoutElement.flexibleWidth = newScale;
		}


		public void OnPointerEnter(PointerEventData eventData)
		{
			IsHighlighted = true;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			IsHighlighted = false;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			ClickEvent?.Invoke(BulletType, this);
		}
	}
}
