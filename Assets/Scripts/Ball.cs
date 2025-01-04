using UnityEngine;


namespace TheCircleHunter
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ball : MonoBehaviour
    {
        [Header("Values")]
        [SerializeField] float inicialSpeed;
        [SerializeField] float initialAngle;

        Vector2 direction;

        Rigidbody2D rb;



        void Awake()
        {
            direction = new Vector2();

            rb = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            float angleInRadians = initialAngle * Mathf.Deg2Rad;

            direction = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));
            direction.Normalize();

            rb.AddForce(direction * inicialSpeed);
        }
    }
}
