using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace CrazyPandaTestTask
{
	// In fact, with Area I did everything very simply. It would be good to allocate the interface of the area, maybe a
	// base class, but somehow I didn't get to it
	
	public class ChronoArea : MonoBehaviour
	{
		[SerializeField]
		private AreaBlendMode BlendMode;
		[SerializeField]
		private Range TimeWrapRange;
		[SerializeField, Tooltip("A value of 0 corresponds to the center of the area, a value of 1 to its edge")]
		private AnimationCurve Curve = AnimationCurve.Constant(0, 1, 1);
		[SerializeField]
		private float Distance = 1;
		
		private Dictionary<IChronoObject, ChronoAreaProvider> _chronoObjects = new();
		
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.TryGetComponent(out IChronoObject chronoObject) && _chronoObjects.ContainsKey(chronoObject) == false)
			{
				ChronoAreaProvider provider = new(BlendMode);
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

		public void Active()
		{
			gameObject.SetActive(true);
		}

		public void DeActive()
		{
			gameObject.SetActive(false);
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
			float sqrDistanceToObject = (chronoObject.Position - (Vector2)transform.position).sqrMagnitude;
			float sqrDistance = Distance * Distance;
			float positionInsideArea = Mathf.InverseLerp(0, sqrDistance, sqrDistanceToObject);

			float curveFactor = Curve.Evaluate(positionInsideArea);
			float newScale = TimeWrapRange.Lerp(curveFactor);

			provider.TimeWrapValue = newScale;
		}
	}
}