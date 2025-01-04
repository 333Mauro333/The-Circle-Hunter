using System;

using UnityEngine;


namespace TheCircleHunter
{
    public class ScoreSingleton : MonoBehaviour
    {
        static ScoreSingleton instance;

		public event Action<int> OnScoreChanged;

        int score;



		void Awake()
		{
			if (instance == null)
			{
				instance = this;
				DontDestroyOnLoad(gameObject);

				score = 0;
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
		public void ResetScore()
		{
			score = 0;
			OnScoreChanged?.Invoke(score);
		}

		public int GetScore()
		{
			return score;
		}
	}
}
