using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CrazyPandaTestTask
{
	public class ChronoObject : MonoBehaviour, IChronoObject, ITimeProviderDecorator
	{
		public float DeltaTime => DecoratorScale * OriginProvider.DeltaTime;
		public float FixedDeltaTime => DecoratorScale * OriginProvider.FixedDeltaTime;
		public float TimeScale => DecoratorScale * OriginProvider.TimeScale;
		public event Action<float, float> ChangeTimeScaleEvent;
		public float DecoratorScale { get; private set; }
		public ITimeProvider OriginProvider { get; private set; }

		private List<ChronoAreaProvider> _areaProviders;

		public void Init(ITimeProvider originProvider)
		{
			OriginProvider = originProvider;
			DecoratorScale = 1;
			
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
			float averageAreasTimeWrap = CalculateAverageAreasTimeWrap();
			float currentScale = averageAreasTimeWrap * OriginProvider.TimeScale;

			if (currentScale.IsNotEquals(TimeScale)) 
				UpdateTimeScale(averageAreasTimeWrap);
		}

		private float CalculateAverageAreasTimeWrap()
		{
			if (_areaProviders.Count == 0)
				return 1;
			
			return _areaProviders.Sum(p => p.TimeWrapValue) / _areaProviders.Count;
		}

		private void UpdateTimeScale(float averageAreasTimeWrap)
		{
			float previousScale = TimeScale;
			DecoratorScale = averageAreasTimeWrap;

			ChangeTimeScaleEvent?.Invoke(previousScale, TimeScale);
		}
	}
}