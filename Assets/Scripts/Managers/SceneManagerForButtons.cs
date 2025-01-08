using UnityEngine;


namespace TheCircleHunter
{
    public class SceneManagerForButtons : MonoBehaviour
    {
		SceneManager sceneManager;



		void Start()
		{
			sceneManager = GameObject.FindWithTag("SceneManager").GetComponent<SceneManager>();
		}



		public void LoadMainMenuScene()
		{
			SceneManager.GetInstance().LoadMainMenuScene();
		}
		public void LoadGameplayScene()
		{
			SceneManager.GetInstance().LoadGameplayScene();
		}
		public void LoadUpgradesScene()
		{
			SceneManager.GetInstance().LoadUpgradesScene();
		}
		public void QuitGame()
		{
			SceneManager.GetInstance().QuitGame();
		}
	}
}
