using UnityEngine;


namespace TheCircleHunter
{
    [RequireComponent(typeof(Collider2D))]
	public class BallOnClick : MonoBehaviour
    {
		[Header("Values")]
		[SerializeField] int valueInPoints;



		void OnMouseDown()
		{
			ScoreSingleton.GetInstance().AddScore(valueInPoints);

            Destroy(gameObject);
		}
	}
}
