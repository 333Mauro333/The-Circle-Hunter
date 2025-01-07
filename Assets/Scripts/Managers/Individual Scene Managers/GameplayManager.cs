using UnityEngine;

using TMPro;


namespace TheCircleHunter
{
    public class GameplayManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] GameObject panelGameOver;
        [SerializeField] TextMeshProUGUI scoreNumberText;



        void Start()
        {
            TimeSingleton.GetInstance().OnTimeFinished += ActivateObjects;
			TimeSingleton.GetInstance().OnTimeFinished += SetScoreInText;

            TimeSingleton.GetInstance().ResetTime();
            ScoreSingleton.GetInstance().ResetScore();
		}

		void OnDestroy()
		{
			TimeSingleton.GetInstance().OnTimeFinished -= ActivateObjects;
			TimeSingleton.GetInstance().OnTimeFinished -= SetScoreInText;
		}



		void ActivateObjects()
        {
            panelGameOver.SetActive(true);
		}
        void SetScoreInText()
        {
            scoreNumberText.text = ScoreSingleton.GetInstance().GetScore().ToString();
        }
    }
}
