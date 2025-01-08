using System;

using UnityEngine;


namespace TheCircleHunter
{
    public class ScoreSingleton : MonoBehaviour
    {
        static ScoreSingleton instance;

		public event Action<int> OnScoreChanged;

        int score;
		int highscore;



		void Awake()
		{
			if (instance == null)
			{
				instance = this;
				DontDestroyOnLoad(gameObject);

				score = 0;
				highscore = 0;
			}
			else
			{
				Destroy(gameObject);
			}
		}



		public static ScoreSingleton GetInstance()
		{
			return instance;
		}

		public void AddScore(int scoreToAdd)
		{
			score += scoreToAdd;
			OnScoreChanged?.Invoke(score);
		}
		public void SaveHighscore()
		{
			highscore = score;
		}
		public void ResetScore()
		{
			score = 0;
			OnScoreChanged?.Invoke(score);
		}
		public void ResetHighscore()
		{
			highscore = 0;
		}

		public int GetScore()
		{
			return score;
		}
		public int GetHighscore()
		{
			return highscore;
		}
	}
}
