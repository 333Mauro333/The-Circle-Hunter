using UnityEngine;


namespace TheCircleHunter
{
    [RequireComponent(typeof(Collider2D))]
	public class BallOnClick : MonoBehaviour
    {
		[Header("Values")]
		[SerializeField] int valueInPoints;

		[Header("References")]
		[SerializeField] BallManager bm;



		void OnMouseDown()
		{
			if (!TimeSingleton.GetInstance().IsTheTimeOver())
			{
				ScoreSingleton.GetInstance().AddScore(valueInPoints);

				bm.RemoveBallFromList(gameObject);

				Destroy(gameObject);
			}
		}



		public void SetBallManager(BallManager ballManager)
		{
			bm = ballManager;
		}
	}
}
