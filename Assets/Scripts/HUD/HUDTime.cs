using UnityEngine;

using TMPro;


namespace TheCircleHunter
{
	public class HUDTime : MonoBehaviour
	{
		[Header("References")]
		[SerializeField] TextMeshProUGUI tmpTime;



		void Start()
		{
			TimeSingleton.GetInstance().OnTimeChanged += UpdateTime;
		}

		void OnDestroy()
		{
			TimeSingleton.GetInstance().OnTimeChanged -= UpdateTime;
		}



		public void UpdateTime(float newTime)
		{
			if (newTime >= 10.0f)
			{
				tmpTime.text = newTime.ToString("00");
			}
			else
			{
				tmpTime.text = newTime.ToString("0.0");
			}
		}
	}
}
