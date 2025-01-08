using UnityEngine;


namespace TheCircleHunter
{
    public class SceneManager : MonoBehaviour
    {
		static SceneManager instance;



		void Awake()
		{
			if (instance == null)
			{
				instance = this;
				DontDestroyOnLoad(gameObject);
			}
			else
			{
				Destroy(gameObject);
			}
		}



		public static SceneManager GetInstance()
		{
			return instance;
		}

		public void LoadScene(string sceneName)
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
		}

		public void LoadMainMenuScene()
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
		}
		public void LoadGameplayScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
        }
		public void LoadUpgradesScene()
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("Upgrades");
		}
		public void QuitGame()
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
		}
	}
}
