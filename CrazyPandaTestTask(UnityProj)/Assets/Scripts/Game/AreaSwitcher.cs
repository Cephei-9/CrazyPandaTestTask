using CrazyPandaTestTask.Input;
using UnityEngine;

namespace CrazyPandaTestTask.Game
{
	public class AreaSwitcher : MonoBehaviour
	{
		[SerializeField]
		private int StartRightIndex, StartLeftIndex;
		[Space]
		[SerializeField]
		private ChronoArea.ChronoArea[] LeftAreas;
		[SerializeField]
		private ChronoArea.ChronoArea[] RightAreas;

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
			private ChronoArea.ChronoArea[] _areas;

			private int _currentIndex;

			public AreasList(ChronoArea.ChronoArea[] areas, int startIndex)
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

			private static void DeActiveAllAreas(ChronoArea.ChronoArea[] areas)
			{
				foreach (ChronoArea.ChronoArea chronoArea in areas)
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