using UnityEngine;


namespace TheCircleHunter
{
    public class LoadingSceneManager : MonoBehaviour
    {
	    [SerializeField] string nextSceneName;



	    void Update()
        {
            SceneManager.GetInstance().LoadScene(nextSceneName);
        }
    }
}
