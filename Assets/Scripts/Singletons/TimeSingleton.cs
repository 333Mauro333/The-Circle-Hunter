using System;

using UnityEngine;


namespace TheCircleHunter
{
	public class TimeSingleton : MonoBehaviour
	{
		static TimeSingleton instance;

		public event Action<float> OnTimeChanged;
		public event Action OnTimeFinished;

		public bool isDiscounting;
		float initialTime;
		float time;
		int intTime;



		void Awake()
		{
			if (instance == null)
			{
				instance = this;
				DontDestroyOnLoad(gameObject);

				InitializeVariables();
			}
			else
			{
				Destroy(gameObject);
			}
		}

		void Update()
		{
			if (isDiscounting)
			{
				int actualIntTime = 0;

				time -= Time.deltaTime;
				actualIntTime = (int)Math.Floor(time);

				if (time >= 10.0f)
				{
					if (intTime != actualIntTime)
					{
						intTime = actualIntTime;
						OnTimeChanged?.Invoke(intTime);
					}
				}
				else
				{
					if (time <= 0.0f)
					{
						time = 0.0f;
						isDiscounting = false;

						OnTimeFinished?.Invoke();
					}

					OnTimeChanged?.Invoke(time);
				}
			}
		}



		public static TimeSingleton GetInstance()
		{
			return instance;
		}

		public void AddTime(float seconds)
		{
			time += seconds;
		}
		public void StartCountDown()
		{
			isDiscounting = true;
		}
		public void PauseTime()
		{
			isDiscounting = false;
		}
		public void ResetTime()
		{
			time = initialTime;
		}

		public bool IsTheTimeOver()
		{
			return time <= 0.0f;
		}

		void InitializeVariables()
		{
			isDiscounting = false;
			initialTime = 20.0f;
			time = initialTime;
			intTime = (int)time;
		}
	}
}
