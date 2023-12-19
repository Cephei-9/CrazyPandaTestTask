using System;
using Chrono;
using Infrastructure.Factory;
using Infrastructure.StaticData;
using Input;
using UnityEngine;
using Zenject;

namespace Game
{
	public class AreaSwitcher : MonoBehaviour
	{
		[Serializable]
		public class Data
		{
			public int StartRightIndex, StartLeftIndex;
		}
		
		[SerializeField]
		private Transform LeftAreasRoot;
		[SerializeField]
		private Transform RightAreasRoot;

		private AreaChangeInput _input;

		private AreasList _leftAreas;
		private AreasList _rightAreas;

		private Data _data;

		[Inject]
		public void Construct(IInput input, IStaticData staticData, IAreaFactory areaFactory)
		{
			_input = input.AreaChangeInput;
			_data = staticData.AreaSwitcherData;

			CreateAreas(areaFactory);
		}

		private void Update()
		{
			if(_input.ChangeLeftArea)
				_leftAreas.ActiveNext();
			
			if(_input.ChangeRightArea)
				_rightAreas.ActiveNext();
		}

		private void CreateAreas(IAreaFactory areaFactory)
		{
			IChronoArea[] leftAreas = CreateOneSideAreas(areaFactory, LeftAreasRoot);
			_leftAreas = new AreasList(leftAreas, _data.StartLeftIndex);
			
			IChronoArea[] rightAreas = CreateOneSideAreas(areaFactory, RightAreasRoot);
			_rightAreas = new AreasList(rightAreas, _data.StartRightIndex);
		}

		private static IChronoArea[] CreateOneSideAreas(IAreaFactory areaFactory, Transform sideTransform)
		{
			IChronoArea[] areas = new IChronoArea[(int)AreasType.Max];
			InstantiateData instantiateData = new(sideTransform.position, Quaternion.identity, sideTransform);

			for (int i = 0; i < (int)AreasType.Max; i++)
			{
				areas[i] = areaFactory.CreateArea((AreasType)i, instantiateData);
			}

			return areas;
		}

		private struct AreasList
		{
			private readonly IChronoArea[] _areas;

			private int _currentIndex;

			public AreasList(IChronoArea[] areas, int startIndex)
			{
				_areas = areas;
				_currentIndex = Mathf.Clamp(startIndex, 0, _areas.Length);
				
				DeActiveAllAreas(areas);
				ActiveCurrentArea(true);
			}

			public void ActiveNext()
			{
				ActiveCurrentArea(false);
				
				_currentIndex++;

				if (_currentIndex == _areas.Length)
					_currentIndex = 0;

				ActiveCurrentArea(true);
			}

			private static void DeActiveAllAreas(IChronoArea[] areas)
			{
				foreach (IChronoArea chronoArea in areas)
				{
					chronoArea.SetActiveStatus(false);
				}
			}

			private void ActiveCurrentArea(bool activeStatus)
			{
				_areas[_currentIndex].SetActiveStatus(activeStatus);
			}
		}
	}
}