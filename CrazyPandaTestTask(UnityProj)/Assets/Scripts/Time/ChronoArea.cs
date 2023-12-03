using System;
using System.Collections.Generic;
using UnityEngine;

namespace CrazyPandaTestTask
{
	public class ChronoArea : MonoBehaviour
	{
		public float TimeWrapValue;
		
		private Dictionary<IChronoObject, ChronoAreaProvider> _chronoObjects = new();
		
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.TryGetComponent(out IChronoObject chronoObject) && _chronoObjects.ContainsKey(chronoObject) == false)
			{
				ChronoAreaProvider provider = new(TimeWrapValue);
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
	}
}