using UnityEngine;


namespace TheCircleHunter
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BallMovement : MonoBehaviour
    {
        Vector2 direction;

        Rigidbody2D rb;



        void Awake()
        {
			rb = GetComponent<Rigidbody2D>();
		}



        public void SetDirection(float angles)
        {
			float angleInRadians = angles * Mathf.Deg2Rad;

			direction = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));
			direction.Normalize();
		}
        public void SetSpeed(float speed)
        {
            StopMovement();

			rb.AddForce(direction * speed);
		}

        public void StopMovement()
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0.0f;
        }
    }
}
