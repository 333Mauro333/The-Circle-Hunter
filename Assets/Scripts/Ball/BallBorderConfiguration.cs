using UnityEngine;


namespace TheCircleHunter
{
    public class BallBorderConfiguration : MonoBehaviour
    {
        [Header("Values")]
        [SerializeField] float offset;

        [Header("References")]
        [SerializeField] Transform childrenColorGameObject;



        void Start()
        {
            childrenColorGameObject.SetParent(null);
            childrenColorGameObject.localScale = transform.localScale - new Vector3(offset, offset);
			childrenColorGameObject.SetParent(transform);
		}
    }
}
