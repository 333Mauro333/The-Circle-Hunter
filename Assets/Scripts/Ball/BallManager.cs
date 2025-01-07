using System.Collections.Generic;

using UnityEngine;


namespace TheCircleHunter
{
    public class BallManager : MonoBehaviour
    {
        [SerializeField] List<GameObject> ballList;

        List<BallMovement> ballMovementScripts;



        void Start()
        {
            ballMovementScripts = new List<BallMovement>();

            // Borrar código cuando las bolas se generen.
            for (int i = 0; i < ballList.Count; i++)
            {
                BallMovement ballScript = ballList[i].GetComponent<BallMovement>();

                ballMovementScripts.Add(ballScript);
            }

            TimeSingleton.GetInstance().OnTimeFinished += StopAllBalls;
        }

		void OnDestroy()
		{
			TimeSingleton.GetInstance().OnTimeFinished -= StopAllBalls;
		}

		// Agregar Update cuando haga aparecer las bolas.



		public void StopAllBalls()
        {
            for (int i = 0; i < ballList.Count; i++)
            {
                ballMovementScripts[i].StopMovement();
            }
        }

        public void RemoveBallFromList(GameObject ballObject)
        {
            BallMovement ballMovementScript = ballObject.GetComponent<BallMovement>();

            ballList.Remove(ballObject);
            ballMovementScripts.Remove(ballMovementScript);
        }
    }
}
