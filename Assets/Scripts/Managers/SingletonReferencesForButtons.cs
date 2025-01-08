using UnityEngine;


namespace TheCircleHunter
{
    public class SingletonReferencesForButtons : MonoBehaviour
    {
		SceneManager sceneManager;
		TimeSingleton timeSingleton;



		void Start()
		{
			sceneManager = GameObject.FindWithTag("SceneManager").GetComponent<SceneManager>();
			timeSingleton = GameObject.FindWithTag("TimeSingleton").GetComponent<TimeSingleton>();
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

		public void StartCountdown()
		{
			timeSingleton.StartCountdown();
		}
	}
}
