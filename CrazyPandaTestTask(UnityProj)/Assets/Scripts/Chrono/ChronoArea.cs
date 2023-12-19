using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Range = Tools.Range;

namespace Chrono
{
	public class ChronoArea : MonoBehaviour, IChronoArea
	{
		[Serializable]
		public class Data
		{
			public AreaBlendMode BlendMode;
			public Range TimeWrapRange;
			public AnimationCurve Curve = AnimationCurve.Constant(0, 1, 1);
			[FormerlySerializedAs("Distance")]
			public float Radius = 1;
			[Space]
			// Of course the view settings should not be in Data but for simplicity I did it here instead of customizing it in the prefabs
			public Color Color = Color.white;
		}

		[SerializeField]
		private SpriteRenderer Renderer;

		private Data _data;
		
		private Dictionary<IChronoObject, ChronoAreaProvider> _chronoObjects = new();

		public void InitData(Data data)
		{
			_data = data;
			
			Renderer.color = data.Color;
			transform.localScale = Vector3.one * (data.Radius * 2);
		}
		
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.TryGetComponent(out IChronoObject chronoObject) && _chronoObjects.ContainsKey(chronoObject) == false)
			{
				ChronoAreaProvider provider = new(_data.BlendMode);
				CalculateObjectScale(chronoObject, provider);
				
				_chronoObjects.Add(chronoObject, provider);
				
				chronoObject.EnterArea(provider);
			}
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (other.TryGetComponent(out IChronoObject timeWrapObject) && 
			    _chronoObjects.TryGetValue(timeWrapObject, out ChronoAreaProvider provider))
			{
				timeWrapObject.ExitArea(provider);
				_chronoObjects.Remove(timeWrapObject);
			}
		}

		private void Update()
		{
			UpdateAllChronoObject();
		}

		public void SetActiveStatus(bool status)
		{
			gameObject.SetActive(status);
		}

		private void UpdateAllChronoObject()
		{
			foreach (KeyValuePair<IChronoObject, ChronoAreaProvider> keyValuePair in _chronoObjects)
			{
				CalculateObjectScale(keyValuePair.Key, keyValuePair.Value);
			}
		}

		private void CalculateObjectScale(IChronoObject chronoObject, ChronoAreaProvider provider)
		{
			float distanceToObject = (chronoObject.Position - (Vector2)transform.position).magnitude;
			float positionInsideArea = Mathf.InverseLerp(0, _data.Radius, distanceToObject);

			float curveFactor = _data.Curve.Evaluate(positionInsideArea);
			float newScale = _data.TimeWrapRange.Lerp(curveFactor);

			provider.TimeWrapValue = newScale;
		}
	}
}