using UnityEngine;


namespace TheCircleHunter
{
	public class MainMenuManager : MonoBehaviour
	{
		public void LoadGameplayScene()
		{
			SceneManager.GetInstance().LoadGameplayScene();
		}
		public void QuitGame()
		{
			SceneManager.GetInstance().QuitGame();
		}
	}
}
