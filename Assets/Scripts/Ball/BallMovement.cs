using UnityEngine;


namespace TheCircleHunter
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BallMovement : MonoBehaviour
    {
        [Header("Values")]
        [SerializeField] float inicialSpeed;
        [SerializeField] float initialAngle;

        Vector2 direction;

        Rigidbody2D rb;



        void Awake()
        {
			float angleInRadians = initialAngle * Mathf.Deg2Rad;

			direction = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));
			direction.Normalize();

			rb = GetComponent<Rigidbody2D>();
			rb.AddForce(direction * inicialSpeed);
		}



        public void StopMovement()
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0.0f;
            rb.isKinematic = true;
        }
    }
}
