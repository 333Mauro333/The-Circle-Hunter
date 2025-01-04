using UnityEngine;


namespace TheCircleHunter
{
    [RequireComponent(typeof(Collider2D))]
	public class BallOnClick : MonoBehaviour
    {
        void OnMouseDown()
		{
            Destroy(gameObject);
		}
	}
}
