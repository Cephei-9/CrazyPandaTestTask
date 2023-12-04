using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CrazyPandaTestTask
{
	public class ChronoObject : MonoBehaviour, IChronoObject, ITimeProviderDecorator
	{
		public float DecoratorScaleView;
		public float TimeScaleView;
		
		//
		
		private List<ChronoAreaProvider> _areaProviders;

		public Vector2 Position => transform.position;
		
		public float DeltaTime => DecoratorScale * OriginProvider.DeltaTime;
		public float FixedDeltaTime => DecoratorScale * OriginProvider.FixedDeltaTime;
		public float TimeScale => DecoratorScale * OriginProvider.TimeScale;
		public event Action<float, float> ChangeTimeScaleEvent;
		public float DecoratorScale { get; private set; }
		public ITimeProvider OriginProvider { get; private set; }

		public void Init(ITimeProvider originProvider)
		{
			OriginProvider = originProvider;
			UpdateTimeScale(1);
			
			_areaProviders = new List<ChronoAreaProvider>();
		}

		private void Start()
		{
			if(OriginProvider == null)
				Init(ITimeProvider.Default);
		}

		public void EnterArea(ChronoAreaProvider areaProvider)
		{
			_areaProviders.Add(areaProvider);
		}

		public void ExitArea(ChronoAreaProvider areaProvider)
		{
			_areaProviders.SmartRemove(areaProvider);
		}

		private void Update()
		{
			float areasTimeWrap = ChronoAreaProvider.BlendAreasTimeWrap(_areaProviders);
			float currentScale = areasTimeWrap * OriginProvider.TimeScale;

			if (currentScale.IsNotEquals(TimeScale)) 
				UpdateTimeScale(areasTimeWrap);

			DecoratorScaleView = DecoratorScale;
			TimeScaleView = TimeScale;
		}
		
		private void UpdateTimeScale(float averageAreasTimeWrap)
		{
			float previousScale = TimeScale;
			DecoratorScale = averageAreasTimeWrap;

			ChangeTimeScaleEvent?.Invoke(previousScale, TimeScale);
		}
	}
}