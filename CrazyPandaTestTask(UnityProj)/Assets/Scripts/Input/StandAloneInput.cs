using DefaultNamespace.Runtime;
using UnityEngine;

namespace DefaultNamespace
{
	public class StandAloneInput : IInput, IUpdatable
	{
		public GunInput RightGunInput { get; }
		public GunInput LeftGunInput { get; }
		public AreaChangeInput AreaChangeInput { get; }

		public StandAloneInput()
		{
			RightGunInput = new GunInput();
			LeftGunInput = new GunInput();
			AreaChangeInput = new AreaChangeInput();
		}

		public void UpdateWork()
		{
			if (HandleAreaInput())
				return;
			
			HandleGunInput(0, LeftGunInput);
			HandleGunInput(1, RightGunInput);
		}

		private bool HandleAreaInput()
		{
			AreaChangeInput.ChangeLeftArea = CheckButtonPressed(0, KeyCode.LeftControl, KeyCode.LeftShift);
			AreaChangeInput.ChangeRightArea = CheckButtonPressed(1, KeyCode.LeftControl, KeyCode.LeftShift);

			return AreaChangeInput.ChangeLeftArea || AreaChangeInput.ChangeRightArea;
		}

		private void HandleGunInput(int mouseButtonIndex, GunInput gunInput)
		{
			gunInput.ChangeBullet = CheckButtonPressed(mouseButtonIndex, KeyCode.LeftControl);
			
			if(!gunInput.ChangeBullet)
				gunInput.Shoot = CheckButtonPressed(mouseButtonIndex);
		}

		private bool CheckButtonPressed(int mouseButtonIndex, params KeyCode[] modifiers)
		{
			foreach (KeyCode keyCode in modifiers)
			{
				if (Input.GetKey(keyCode) == false)
					return false;
			}

			return Input.GetMouseButtonDown(mouseButtonIndex);
		}
	}
}