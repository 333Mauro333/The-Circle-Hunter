using UnityEngine;

using TMPro;


namespace TheCircleHunter
{
    public class GameplayManager : MonoBehaviour
    {
        [Header("References")]
		[SerializeField] GameObject panelGameOver;
        [SerializeField] TextMeshProUGUI scoreNumberText;
		[SerializeField] TextMeshProUGUI highscoreNumberText;



		void Start()
        {
            TimeSingleton.GetInstance().OnTimeFinished += ActivateObject;
			TimeSingleton.GetInstance().OnTimeFinished += SetScoreInText;
			TimeSingleton.GetInstance().OnTimeFinished += SaveAndSetHighscoreInText;

			TimeSingleton.GetInstance().ResetTime();
            ScoreSingleton.GetInstance().ResetScore();
		}

		void OnDestroy()
		{
			TimeSingleton.GetInstance().OnTimeFinished -= ActivateObject;
			TimeSingleton.GetInstance().OnTimeFinished -= SetScoreInText;
			TimeSingleton.GetInstance().OnTimeFinished -= SaveAndSetHighscoreInText;
		}



		void ActivateObject()
        {
            panelGameOver.SetActive(true);
		}
        void SetScoreInText()
        {
            scoreNumberText.text = ScoreSingleton.GetInstance().GetScore().ToString();
        }
		void SaveAndSetHighscoreInText()
		{
			if (ScoreSingleton.GetInstance().GetScore() > ScoreSingleton.GetInstance().GetHighscore())
			{
				ScoreSingleton.GetInstance().SaveHighscore();
			}

			highscoreNumberText.text = ScoreSingleton.GetInstance().GetHighscore().ToString();
		}
	}
}
