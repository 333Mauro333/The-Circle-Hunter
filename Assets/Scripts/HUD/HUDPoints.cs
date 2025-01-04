using UnityEngine;

using TMPro;


namespace TheCircleHunter
{
    public class HUDPoints : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] TextMeshProUGUI tmpPoints;



		void Start()
		{
            ScoreSingleton.GetInstance().OnScoreChanged += UpdatePoints;
		}

		void OnDestroy()
		{
			ScoreSingleton.GetInstance().OnScoreChanged -= UpdatePoints;
		}



		public void UpdatePoints(int points)
        {
            tmpPoints.text = points.ToString();
        }
    }
}
