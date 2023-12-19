using UnityEngine;

namespace Game
{
	public class LevelContext : MonoBehaviour
	{
		[SerializeField]
		private Gun LeftGun;
		[SerializeField]
		private Gun RightGun;

		public Gun GetLeftGun => LeftGun;
		public Gun GetRightGun => RightGun;
	}
}