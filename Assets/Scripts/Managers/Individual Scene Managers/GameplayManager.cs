using UnityEngine;

using TMPro;


namespace TheCircleHunter
{
    public class GameplayManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] TextMeshProUGUI timeText;
        [SerializeField] GameObject panelGameOver;
        [SerializeField] TextMeshProUGUI scoreNumberText;



        void Start()
        {
            TimeSingleton.GetInstance().OnTimeFinished += ActivateObject;
			TimeSingleton.GetInstance().OnTimeFinished += SetScoreInText;

            TimeSingleton.GetInstance().ResetTime();
            ScoreSingleton.GetInstance().ResetScore();
		}

		void OnDestroy()
		{
			TimeSingleton.GetInstance().OnTimeFinished -= ActivateObject;
			TimeSingleton.GetInstance().OnTimeFinished -= SetScoreInText;
		}



		void ActivateObject()
        {
            panelGameOver.SetActive(true);
		}
        void SetScoreInText()
        {
            scoreNumberText.text = ScoreSingleton.GetInstance().GetScore().ToString();
        }
    }
}
