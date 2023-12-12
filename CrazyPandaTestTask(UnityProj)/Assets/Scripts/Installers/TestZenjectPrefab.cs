using System;
using CrazyPandaTestTask.Input;
using CrazyPandaTestTask.UI;
using UnityEngine;
using Zenject;

namespace Installers
{
	public class TestZenjectPrefab : MonoBehaviour
	{
		[Inject]
		public void Construct(IInput input, ITimeScaleView scaleView)
		{
			Debug.Log("Recieve Input: " + (input != null));
		}
		
		private void Start()
		{
			Debug.Log("Instantiate Start");
		}
	}
}