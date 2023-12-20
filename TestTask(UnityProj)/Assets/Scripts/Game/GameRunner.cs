using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
	public class GameRunner : MonoBehaviour
	{
		public static bool IsInit; 
		
		private const int START_SCENE_INDEX = 0;

		private void Awake()
		{
			if(IsInit == false)
				SceneManager.LoadScene(START_SCENE_INDEX);
		}
	}
}