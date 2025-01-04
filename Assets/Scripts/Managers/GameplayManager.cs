using UnityEngine;


namespace TheCircleHunter
{
    public class GameplayManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] GameObject panelGameOver;



        void Start()
        {
            TimeSingleton.GetInstance().OnTimeFinished += ActivateObject;
        }

		void OnDestroy()
		{
			TimeSingleton.GetInstance().OnTimeFinished -= ActivateObject;
		}



		void ActivateObject()
        {
            panelGameOver.SetActive(true);
		}
    }
}
