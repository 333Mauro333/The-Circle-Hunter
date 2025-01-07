using System;

using UnityEngine;


namespace TheCircleHunter
{
	public class TimeSingleton : MonoBehaviour
	{
		static TimeSingleton instance;

		[SerializeField] float initialTime;

		public event Action<float> OnTimeChanged;
		public event Action OnTimeFinished;

		public bool isDiscounting;
		float actualTime;
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

				actualTime -= Time.deltaTime;
				actualIntTime = (int)Math.Floor(actualTime);

				if (actualTime >= 10.0f)
				{
					if (intTime != actualIntTime)
					{
						intTime = actualIntTime;
						OnTimeChanged?.Invoke(intTime);
					}
				}
				else
				{
					if (actualTime <= 0.0f)
					{
						actualTime = 0.0f;
						isDiscounting = false;

						OnTimeFinished?.Invoke();
					}

					OnTimeChanged?.Invoke(actualTime);
				}
			}
		}



		public static TimeSingleton GetInstance()
		{
			return instance;
		}

		public float GetActualTime()
		{
			return actualTime;
		}

		public void AddTime(float seconds)
		{
			actualTime += seconds;

			OnTimeChanged?.Invoke(actualTime);
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
			actualTime = initialTime;

			OnTimeChanged?.Invoke(actualTime);
		}

		public bool IsTheTimeOver()
		{
			return actualTime <= 0.0f;
		}

		void InitializeVariables()
		{
			isDiscounting = false;
			actualTime = initialTime;
			intTime = (int)actualTime;
		}
	}
}
