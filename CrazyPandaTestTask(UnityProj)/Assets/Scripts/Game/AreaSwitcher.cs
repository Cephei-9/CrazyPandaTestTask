using System;
using System.Collections.Generic;
using CrazyPandaTestTask;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
	public class AreaSwitcher : MonoBehaviour
	{
		[SerializeField]
		private int StartRightIndex, StartLeftIndex;
		[Space]
		[SerializeField]
		private ChronoArea[] LeftAreas;
		[SerializeField]
		private ChronoArea[] RightAreas;

		private AreaChangeInput _input;

		private AreasList _leftAreas;
		private AreasList _rightAreas;

		private void Awake()
		{
			_leftAreas = new AreasList(LeftAreas, StartLeftIndex);
			_rightAreas = new AreasList(RightAreas, StartRightIndex);
		}

		public void Init(AreaChangeInput input)
		{
			_input = input;
		}

		private void Update()
		{
			if(_input.ChangeLeftArea)
				_leftAreas.ActiveNext();
			
			if(_input.ChangeRightArea)
				_rightAreas.ActiveNext();
		}

		private struct AreasList
		{
			private ChronoArea[] _areas;

			private int _currentIndex;

			public AreasList(ChronoArea[] areas, int currentIndex)
			{
				_areas = areas;
				_currentIndex = currentIndex;
				
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

			private static void DeActiveAllAreas(ChronoArea[] areas)
			{
				foreach (ChronoArea chronoArea in areas)
				{
					chronoArea.DeActive();
				}
			}

			private void ActiveCurrentArea(bool activeStatus)
			{
				if(activeStatus)
					_areas[_currentIndex].Active();
				else
					_areas[_currentIndex].DeActive();
			}
		}
	}
}