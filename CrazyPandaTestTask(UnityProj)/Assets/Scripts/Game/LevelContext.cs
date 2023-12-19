using UnityEngine;

namespace CrazyPandaTestTask.Game
{
	public class LevelContext : MonoBehaviour
	{
		[SerializeField]
		private Gun _leftGun;
		[SerializeField]
		private Gun _rightGun;

		public Gun LeftGun => _leftGun;
		public Gun RightGun => _rightGun;
	}
}